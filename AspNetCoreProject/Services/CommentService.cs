using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Services
{
    public class CommentService : ICommentService
    {
        public AnimalDBContext _context;
        public CommentService(AnimalDBContext context)
        {
            _context = context;
        }
    }
}
