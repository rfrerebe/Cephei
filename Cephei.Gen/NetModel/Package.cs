﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Cephei.Gen.NetModel
{
    public class Package
    {
        public string Name;
        public int Id;
        public string Guid;
        public int? ParentId;
        public Package Parent;
        public List<Package> Children;
        public Dictionary<int, Class> ClasseByIds;
        private List<Class> _ClassByDependancy = null;

        public Package (string guid) 
        {
            var p = (from r in Context.Current.Value.DB.Packages
                     where r.GUID == guid
                     select r).FirstOrDefault();

            if (p != null)
            {
                Name = p.Name;
                Id = p.Id;
                ParentId = p.ParentId;
                Guid = p.GUID;
                Children = new List<Package>(GetPackageByParentId(Id));
            }
        }

        public Package (EA.Gen.Model.IPackage p)
        {
            Name = p.Name;
            Id = p.Id;
            ParentId = p.ParentId;

            Children = new List<Package>(GetPackageByParentId(Id));
        }

        private Dictionary<string, Class> _Classes = null;
        public Dictionary<string, Class> Classes
        {
            get
            {
                if (_Classes == null)
                {
                    _Classes = Class.GetClassesByPackage(this);
                    Link();
                }
                return _Classes;
            }
        }



        public List<Class> ClassesByDependancy()
        {
            if (_ClassByDependancy != null) return _ClassByDependancy;

            var q = (from r in Classes
                     select r.Value);

            _ClassByDependancy = (from r in q
                                  orderby r.DependancyDepth()
                                  select r).ToList();

            return _ClassByDependancy;
        }

        private bool _linked = false;
        public void Link ()
        {
            if (_linked) return;
            ClasseByIds = (from r in Classes
                           select r.Value).ToDictionary(p => p.Id);
            foreach (var p in Children)
                p.Link();
            foreach (var v in Classes)
                v.Value.Link(ClasseByIds);
            _linked = true;
        }


        public Class FindByStack(Stack<string> q)
        {
            if (q.Peek() == Name)
                q.Pop();
            foreach (var v in Classes)
            {
                var r = v.Value.FindByStack(q, true);
                if (r != null) return r;
            }
            foreach (var v in Children)
            {
                var r = v.FindByStack(q);
                if (r != null) return r;
            }
            return null;
        }

        public Package getPackage (string guid)
        {
            if (guid == Guid) 
                return this;
            else
                foreach(var p in Children)
                {
                    var c = p.getPackage(guid);
                    if (c != null)
                        return c;
                }
            return null;
        }

        public static IEnumerable<Package> GetPackageByParentId(int id)
        {
            var q = (from r in Context.Current.Value.DB.Packages
                     where r.ParentId == id
                     select r).ToArray();

            return from r in q
                   select new Package(r);
        }            
    }
}