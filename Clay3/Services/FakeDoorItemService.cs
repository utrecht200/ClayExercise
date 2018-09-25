using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Clay3.Models;

namespace Clay3.Services
{
    public class FakeDoorItemService : IDoorItemService
    {

        private readonly ApplicationDbContext _context;

        public FakeDoorItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Fake doors, to be replaced later
        public Task<DoorItem[]> GetDoorItemsAsync()
        {
            var item1 = new DoorItem
            {
                DoorID = Guid.Parse("0f9da56a-5a94-4277-a6b9-d68716a2e066"),
                DoorName = "Tunnel"
            };

            var item2 = new DoorItem
            {
                DoorID = Guid.Parse("7f1dc557-3dc1-4fcf-bcfc-d202d6404e11"),
                DoorName = "Office  "
            };

            return Task.FromResult(new[] { item1, item2 });
        }


        public Task<KeyItem[]> GetKeyItemsAsync()
        {
            var item1 = new KeyItem
            {
                KeyId = Guid.Parse("a4d72185-979b-4080-a1c2-782d08c877cf"),
                DoorId = Guid.Parse("0f9da56a-5a94-4277-a6b9-d68716a2e066"),
                KeyOwner = "admin@123.com",                
            };

            var item2 = new KeyItem
            {
                KeyId = Guid.Parse("8793534b-5725-4d2a-af58-4ef52e0e0d41"),
                DoorId = Guid.Parse("7f1dc557-3dc1-4fcf-bcfc-d202d6404e11"),
                KeyOwner = "admin@123.com",
            };

            var item3 = new KeyItem
            {
                KeyId = Guid.Parse("a4222130-02d7-4e10-870d-a427d58a810a"),
                DoorId = Guid.Parse("0f9da56a-5a94-4277-a6b9-d68716a2e066"),
                KeyOwner = "user@123.com",
            };

            var item4 = new KeyItem
            {
                KeyId = Guid.Parse("1fc0e305-a4a0-429c-b0bc-2cf1d49de196"),
                DoorId = Guid.Parse("7f1dc557-3dc1-4fcf-bcfc-d202d6404e11"),
                KeyOwner = "haha@123.com",
            };

            return Task.FromResult(new[] { item1, item2, item3, item4 });
        }



        public async Task<bool> OpenDoorAsync(ApplicationUser currentUser, Guid door)
        {
            KeyItem[] keys = await GetKeyItemsAsync();  

            bool hasRightKey;
            if (keys.Where( x=> x.KeyOwner == currentUser.Email && x.DoorId == door).Count() ==0)
            {
                hasRightKey = false;
            }
            else { hasRightKey = true; }

            var newRecord = new OpenRecord
            {
                RecordId = Guid.NewGuid(),
                DoorId = door,
                UserName = currentUser.UserName,
                HasOpened = hasRightKey,
                Excuted = DateTime.UtcNow
            };
            _context.OpenRecords.Add(newRecord);

            var saveResult = await _context.SaveChangesAsync();

            return hasRightKey;
            
        }
    }
}