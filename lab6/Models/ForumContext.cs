using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab6.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<UserModel> Users { get;set; }
        public DbSet<ForumCategoryModel> ForumCategories { get; set; }
        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<ReplyModel> Replies { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PictureModel> Pictures { get; set; }
        public DbSet<FolderModel> Folders { get; set; }
        public DbSet<FileModel> Files { get; set; }


        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel { Id = 1, Name = "admin" },
                new RoleModel { Id = 2, Name = "user" } );

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    Email = "admin@example.com",
                    Password = "admin",
                    RoleId = 1
                },
                new UserModel
                {
                    Id = 2,
                    Email = "user@example.com",
                    Password = "user",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 3,
                    Email = "suser@example.com",
                    Password = "suser",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 4,
                    Email = "mod@example.com",
                    Password = "mod",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 5,
                    Email = "salvador@example.com",
                    Password = "salva",
                    RoleId = 2
                });

            modelBuilder.Entity<ForumCategoryModel>().HasData(
                new ForumCategoryModel
                {
                    Id = 1,
                    Name = "An interesting topic",
                    Description = "This topic is definitely interesting."
                },
                new ForumCategoryModel 
                {
                    Id = 2,
                    Name = "Boring topic",
                    Description = "Do not click"
                },
                new ForumCategoryModel
                {
                    Id = 3,
                    Name = "Chatterbox",
                    Description = "Thoughts that are just hard to categorize"
                });

            modelBuilder.Entity<PictureModel>().HasData(
                new PictureModel
                {
                    Id = 1,
                    Name = "alarm",
                    Image = ReadFile("wwwroot/img/alarm.jpg"),
                    ReplyModelId = 1
                },
                new PictureModel
                {
                    Id = 2,
                    Name = "alarm2",
                    Image = ReadFile("wwwroot/img/alarm2.jpg"),
                    ReplyModelId = 1
                },
                new PictureModel
                {
                    Id = 3,
                    Name = "carflip",
                    Image = ReadFile("wwwroot/img/carflip.jpg"),
                    TopicModelId = 4
                },
                new PictureModel
                {
                    Id = 4,
                    Name = "tf",
                    Image = ReadFile("wwwroot/img/tf.jpg"),
                    ReplyModelId = 10
                },
                new PictureModel
                {
                    Id = 5,
                    Name = "cheese",
                    Image = ReadFile("wwwroot/img/cheese.jpg"),
                    ReplyModelId = 5
                },
                new PictureModel
                {
                    Id = 6,
                    Name = "cloudy",
                    Image = ReadFile("wwwroot/img/cloudy.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 7,
                    Name = "snowy",
                    Image = ReadFile("wwwroot/img/snowy.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 8,
                    Name = "puppy",
                    Image = ReadFile("wwwroot/img/puppy.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 9,
                    Name = "iceskating",
                    Image = ReadFile("wwwroot/img/iceskating.jpg"),
                    ReplyModelId = 8
                });

            modelBuilder.Entity<TopicModel>().HasData(
                new TopicModel
                {
                    Id = 1,
                    Title = "Alarms",
                    Description = "You love when it rings",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 4,
                    ForumId = 1,
                    AuthorId = 4,
                    LastReplyId = 4
                },
                new TopicModel
                {
                    Id = 2,
                    Title = "Transformers",
                    Description = "Bzzzhzhzwwwwrrrrooom",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 4,
                    ForumId = 2,
                    AuthorId = 2,
                    LastReplyId = 10,
                    PictureCount = 0
                },
                new TopicModel
                {
                    Id = 3,
                    Title = "Cheese sticks",
                    Description = "Crispy on the inside, soft on the outside",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 0,
                    ForumId = 1,
                    AuthorId = 2
                },
                new TopicModel
                {
                    Id = 4,
                    Title = "I'm simply built different",
                    Description = "Today I flipped a vehicle with my bare arms!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 1,
                    ForumId = 1,
                    AuthorId = 3,
                    LastReplyId = 11,
                    PictureCount = 1
                },
                new TopicModel
                {
                    Id = 5,
                    Title = "3 things I live up to",
                    Description = "Nature is so pleasant. So are puppies",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 0,
                    ForumId = 2,
                    AuthorId = 4,
                    PictureCount = 3
                },
                new TopicModel
                {
                    Id = 6,
                    Title = "I see no future",
                    Description = "Am I blind?",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 4,
                    ForumId = 1,
                    AuthorId = 4,
                    LastReplyId = 4
                });

            modelBuilder.Entity<ReplyModel>().HasData(
                new ReplyModel
                {
                    Id = 1,
                    Text = "The reason I wake up in the morning is to hear my beautiful alarm",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 3,
                    PictureCount = 2
                },
                new ReplyModel
                {
                    Id = 2,
                    Text = "Why did you even post this? I see no Hublot in here...",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 2,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 3,
                    Text = "I thought we're talking about alarms, not fortune",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 3,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 4,
                    Text = "Oh, that's hot!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 5,
                    Text = "Gorgeous!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 6,
                    AuthorId = 2,
                    PictureCount = 1
                 },
                new ReplyModel
                {
                    Id = 6,
                    Text = "Ok, buddy",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 6,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 7,
                    Text = "Whatever",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 3,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 8,
                    Text = "Sometimes I forget why the hell did I log in today...",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 4,
                    PictureCount = 1
                },
                new ReplyModel
                {
                    Id = 9,
                    Text = "BUMBLEBEE!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 10,
                    Text = "this movie is poop",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 3,
                    PictureCount = 1
                },
                new ReplyModel
                {
                    Id = 11,
                    Text = "cringe",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 4,
                    AuthorId = 5,
                    PictureCount = 0
                });           

            modelBuilder.Entity<FolderModel>().HasData(
                new FolderModel
                {
                    Id = 1,
                    Name = "Root"
                });
        }


        // forum entity terminator
       
        public ReplyModel DeleteAllPicturesInReply(ReplyModel reply)
        {
            if (reply.PictureCount != 0)
            {
                foreach (PictureModel pic in reply.Pictures.ToList())
                {
                    reply.Pictures.Remove(pic);
                    this.Pictures.Remove(pic);
                }
            }
            return reply;
        }
        public TopicModel DeleteAllPicturesInTopic(TopicModel topic)
        {
            if (topic.PictureCount != 0)
            {
                foreach (PictureModel pic in topic.Pictures.ToList())
                {
                    topic.Pictures.Remove(pic);
                    this.Pictures.Remove(pic);
                }
            }
            return topic;
        }
        public TopicModel DeleteAllRepliesInTopic(TopicModel topic)
        {
            if(topic.ReplyCount != 0)
            {
                foreach (ReplyModel reply in topic.Replies.ToList())
                {
                    DeleteReply(reply, topic);
                }
            }
            return topic;
        }
        public ForumCategoryModel DeleteAllTopicsInCategory(ForumCategoryModel forumCategory)
        {
            if (forumCategory.Topics.Any())
            {
                foreach (TopicModel topic in forumCategory.Topics.ToList())
                {
                    DeleteTopic(topic);
                }
            }
            return forumCategory;
        }

        public void DeleteForumCategory(ForumCategoryModel forumCategory)
        {
            forumCategory = DeleteAllTopicsInCategory(forumCategory);
            this.ForumCategories.Remove(forumCategory);
        }
        public void DeleteReply(ReplyModel reply, TopicModel topic)
        {
            reply = DeleteAllPicturesInReply(reply);
            topic.Replies.Remove(reply);
            topic.ReplyCount--;
            this.Replies.Remove(reply);
        }
        public void DeleteTopic(TopicModel topic)
        {
            topic = DeleteAllRepliesInTopic(topic);
            topic = DeleteAllPicturesInTopic(topic);
            this.Topics.Remove(topic);
        }
        public void DeleteFile(FileModel file)
        {
           FolderModel folder = this.Folders.FirstOrDefault(x => x.Id == file.FolderId);
           folder.Files.Remove(file);
           this.Files.Remove(file);
        }
        public void DeleteFolder(FolderModel folder)
        {
            FolderModel ParentFolder = this.Folders.FirstOrDefault(x => x.Id == folder.ParentFolderId);
            ParentFolder.Folders.Remove(folder);
            this.Folders.Remove(folder);
        }

        public void DeleteFolderDirectory(FolderModel folder)
        {
            if (folder.Files.Any())
            {
                foreach(FileModel file in folder.Files.ToList())
                {
                    DeleteFile(file);
                }
            }

            if (folder.Folders.Any())
            {
                foreach (FolderModel fld in folder.Folders.ToList())
                {
                    FolderModel fld_temp = this.Folders
                        .Include(x => x.Folders)
                        .Include(x => x.Files)
                        .FirstOrDefault(x => x.Id == fld.Id);

                    if (fld.Folders.Any())
                    {
                        DeleteFolderDirectory(fld);
                    }
                    DeleteFolder(fld);
                } 
            }
            DeleteFolder(folder);
        }



        // method for seeding img data
        public byte[] ReadFile(string path)
        {
            FileInfo fInfo = new(path);
            long numBytes = fInfo.Length;

            FileStream fStream = new(path, FileMode.Open, FileAccess.Read);

            BinaryReader br = new(fStream);

            byte[] data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}