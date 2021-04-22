﻿using ImageMagick;
using Microsoft.AspNetCore.Http;
using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository;
using PhotoryRepository.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats;

namespace PhotoryLogic.Classes
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository userRepo;
        private IUserOfGroupRepository userofgrouprepo;
        private IGroupRepository groupRepo;
     
        public UserLogic(IUserRepository userRepo, IUserOfGroupRepository userofgrouprepo, IGroupRepository groupRepo)
        {
            this.userRepo = userRepo;
            this.userofgrouprepo = userofgrouprepo;
            this.groupRepo = groupRepo;
        }
        public void CreateUser(User user)
        {
                //TODO: hashpw 
                this.userRepo.Add(user);

        }

        public void DeleteUser(string UserID)
        {
                this.userRepo.Delete(UserID);
        }

        public IQueryable<User> GetAllUser()
        {
            return this.userRepo.GetAll();
        }

        public User GetUser(string UserID)
        {
            return this.userRepo.GetOne(UserID);
        }

        public void UpdateUser(string OldID, User user)
        {
           this.userRepo.Update(OldID, user);
        }
        public void AddComment(Comment m)
        {

            m.CommentID = Guid.NewGuid().ToString();
            this.userRepo.AddComment(m);
        }
        
        public void DeleteComment(string CommentID)
        {

                this.userRepo.DeleteComment(CommentID);
        }


        public IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID)
        {

            return this.userRepo.GetAllCommentsFromPhoto(PhotoID);

        }


        public void AddPhoto(Photo p)
        {

                this.userRepo.AddPhoto(p);
        }
        public void DeletePhoto(string PhotoID)
        {

                this.userRepo.DeletePhoto(PhotoID);
        }
        public void RequestJoin(string userID, string GroupID)
        {
            var user = userRepo.GetOne(userID);
            var group = groupRepo.GetOne(GroupID);

            if ((DateTime.Now - user.BirthDate).Days > group.Age*365)
            {
                this.userRepo.RequestJoin(userID, GroupID);
            }
            else
            {
                throw new ArgumentException("Age restrection validation error");
            }
            

        }

        public void LeaveGroup(string userID, string GroupID)
        {
            this.userRepo.LeaveGroup(userID, GroupID);
        }

        public User GetUserFromGroup(string userID, string GroupID) 
        {
            var entity = (from x in userofgrouprepo.GetAll()
                          where x.UserName == userID && x.GroupName == GroupID
                          select x).FirstOrDefault();

            var userentity = userRepo.GetOne(entity.UserName);

            return userentity;
        }

        public void UploadtoData(string fileName, string groupID,string userid)
        {
            var fullpath = Path.Combine(Environment.CurrentDirectory + @"\Photos", fileName);
            if (File.Exists(fullpath) && groupRepo.GetOne(groupID) != null)
            {
                var image = Image.Load(fullpath);
                
                
                
                Photo p = new Photo();
                p.PhotoID = Guid.NewGuid().ToString();
                p.PhotoTitle = fileName;
                p.GroupId = groupID;
                p.UserID = userid;
                p.Height = image.Height;
                p.Width = image.Width;


                image.Mutate(x => x.Resize(200, 200));

                var tmppath = Path.Combine(Environment.CurrentDirectory + @"\Photos", "Data_"+fileName);
                image.Save(tmppath);
                FileInfo f = new FileInfo(tmppath);
                f.Refresh();
                p.PhotoData = File.ReadAllBytes(f.FullName);
                
                //var optimizer = new ImageOptimizer();
                //FileInfo f = new FileInfo();
                //optimizer.Compress(f);
                //f.Refresh();
                //p.PhotoData = File.ReadAllBytes(f.FullName);
                userRepo.AddPhoto(p);
                File.Delete(tmppath);
                File.Delete(fullpath);
                return;
            }   
            throw new Exception("file was not found");

        }
    }
}
