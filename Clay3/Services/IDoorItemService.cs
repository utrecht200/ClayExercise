using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clay3.Models;

namespace Clay3.Services
{
    public interface IDoorItemService
    {
        Task<DoorItem[]> GetDoorItemsAsync();
        Task<OpenRecord[]> GetOpenRecordsAsync();
        Task<bool> OpenDoorAsync(ApplicationUser currentUser, Guid door);
    }
}
