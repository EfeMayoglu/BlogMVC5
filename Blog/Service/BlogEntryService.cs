using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Service;
using Blog.DatabaseContext;


namespace Blog.Service
{
    public class BlogEntryService : EntityService<BlogEntry>, IBlogEntryService
    {
        IDbContext _context;

        public BlogEntryService(IDbContext context) : base(context)
        {
            _context = context;
            _dbset = _context.Set<BlogEntry>();
        }

        public BlogEntry GetById(int? Id)
        {
            return _dbset.Find(Id);
        }

        public override void Create(BlogEntry entity)
        {
            entity.UserName = HttpContext.Current.User.Identity.Name;
            entity.EntryDate = System.DateTime.Now;
            base.Create(entity);
        }
    }
}