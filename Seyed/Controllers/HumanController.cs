using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ← برای ToListAsync
using Seyed.DTOs;
using Seyed.Models;
using System.Globalization;
using System.Net.Sockets;
using System.Text.RegularExpressions;
//Using seyed.humanSearchDto;
// Happy To Git
namespace Seyed.Controllers
{
    // [Route("api/[controller]/[Action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
            private readonly CustomerContext _context;
    
            public HumanController(CustomerContext context)
        {
            _context = context;
        }
    
            private string? ToPersianDate(DateTime? date)
        {
            if (!date.HasValue)
                return null;

            var pc = new PersianCalendar();
            return $"{pc.GetYear(date.Value)}/{pc.GetMonth(date.Value):00}/{pc.GetDayOfMonth(date.Value):00}";
        }
    
    
            [HttpGet("getHuman")]
            public async Task<IActionResult> GetHuman()

        {
            // Lambda for get
            var data = await _context.Humans
            .Join(_context.Clients, h => h.HumanId, c => c.RefId, (h, c) => new { h, c })
            .Join(_context.Addresses, hc => hc.c.ClientId, a => a.ClientId, (hc, a) => new { hc.h, hc.c, a })
            .Where(x => x.h.HumanId > 116991 && x.h.HumanId < 117012 && x.a.AddressTypeId == 1)
            .Select(x => new
            {
                x.h,
                x.c,
                x.a.Address1
            })
            .AsNoTracking()
            .ToListAsync();

            var report = data.Select(x => new HumanReportDto
            {
                HumanId = x.h.HumanId,
                HumanName = x.h.HumanName,
                Family = x.h.Family,
                FatherName = x.h.FatherName,
                RegNo = x.h.RegNo,
                NationalNo = x.h.NationalNo,
                RegPlace = x.h.RegPlace,
                Job = x.h.Job,
                BirthDate = ToPersianDate(x.h.BirthDate),
                CreateDate = ToPersianDate(x.h.CreateDate),
                Sex = x.h.Sex,
                Mobile = x.h.Mobile,
                ClientId = x.c.ClientId,
                CustomerNo = x.c.CustomerNo?.ToString(),
                Address = x.Address1
            }).ToList();
            return Ok(report);
        }
    
            /*/ Linq for get
         * {
                  var data = await (
                      from h in _context.Humans
                      join c in _context.Clients on h.HumanId equals c.RefId
                      join a in _context.Addresses on c.ClientId equals a.ClientId //into addrGroup
                 //   from a in addrGroup
                 //      .Where(x => x.AddressTypeId == 1 && x.Active && !string.IsNullOrEmpty(x.Address1))
                 //       .OrderBy(x => x.Id)
                 //       .Take(1) // فقط اولین آدرس معتبر
                 //       .DefaultIfEmpty()
                      where h.HumanId > 116991 && h.HumanId < 117012 && a.AddressTypeId == 1
                      //  && c.Status == 1
                      select new
                      {
                          h,
                          c,
                          Address = a.Address1
                      }
                  )
                  .AsNoTracking()
                  .ToListAsync();


                  var report = (
                      from x in data
                      select new HumanReportDto
                      {
                          HumanId = x.h.HumanId,
                          HumanName = x.h.HumanName,
                          Family = x.h.Family,
                          FatherName = x.h.FatherName,
                          RegNo = x.h.RegNo,
                          NationalNo = x.h.NationalNo,
                          RegPlace = x.h.RegPlace,
                          Job = x.h.Job,
                          BirthDate = ToPersianDate(x.h.BirthDate),
                          CreateDate = ToPersianDate(x.h.CreateDate),
                          Sex = x.h.Sex,
                          Mobile = x.h.Mobile,
                          ClientId = x.c.ClientId,
                          CustomerNo = x.c.CustomerNo?.ToString(),
                          Address = x.Address
                      }
                  ).ToList();
                  return Ok(report);
           }
            */
            /* Include for Get
       {
           var data = await _context.Humans
               .Include(h => h.Clients)
             //      .ThenInclude(c => c.Addresses)
               .Where(h => h.HumanId > 116991 && h.HumanId < 117012) // فیلتر اصلی
               .AsNoTracking()
               .ToListAsync();

           var report = data.Select(h =>
           {
               //var address = h.Clients.Select(d=>d.Addresses).ToList()
               //    .Where(a => a.AddressTypeId == 1 && a.Active && !string.IsNullOrEmpty(a.Address1))
               //    .OrderBy(a => a.Id)
               //    .Select(a => a.Address1)
               //    .FirstOrDefault();

               return new HumanReportDto
               {
                   HumanId = h.HumanId,
                   HumanName = h.HumanName,
                   Family = h.Family,
                   FatherName = h.FatherName,
                   RegNo = h.RegNo,
                   NationalNo = h.NationalNo,
                   RegPlace = h.RegPlace,
                   Job = h.Job,
                   BirthDate = ToPersianDate(h.BirthDate),
                   CreateDate = ToPersianDate(h.CreateDate),
                   Sex = h.Sex,
                   Mobile = h.Mobile,
               //  ClientId = h.Client?.ClientId ?? 0,
               //  CustomerNo = h.Client?.CustomerNo?.ToString(),
                //   Address = address
               };
           }).ToList();

           return Ok(report);
       }
               // var s =await _context.Humans.Include(x => x.Clients).ThenInclude(d => d.Addresses).Where(h => h.HumanId > 116991).ToListAsync();

       */
    
    
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] HumanSearchDto searchModel)
     
        {
            //   Lambda for Search */
            var query = _context.Humans
                    .Where(x => x.HumanId > 116991 && x.HumanId < 117012)
                    .Join(_context.Clients,
                          h => h.HumanId,
                          c => c.RefId,
                          (h, c) => new { Human = h, Client = c })
                    .Where(hc => hc.Client.Status == 1)
                    .AsQueryable();

            if (searchModel.HumanId.HasValue)
                query = query.Where(h => h.Human.HumanId == searchModel.HumanId.Value);

            if (!string.IsNullOrEmpty(searchModel.HumanName))
                query = query.Where(h => h.Human.HumanName.ToLower().Contains(searchModel.HumanName.Trim().ToLower()));

            if (!string.IsNullOrEmpty(searchModel.Family))
                query = query.Where(h => h.Human.Family.Contains(searchModel.Family));

            if (!string.IsNullOrEmpty(searchModel.FatherName))
                query = query.Where(h => h.Human.FatherName.Contains(searchModel.FatherName));

            if (!string.IsNullOrEmpty(searchModel.RegNo))
                query = query.Where(h => h.Human.RegNo.Contains(searchModel.RegNo));

            if (!string.IsNullOrEmpty(searchModel.NationalNo))
                query = query.Where(h => h.Human.NationalNo.Contains(searchModel.NationalNo));

            if (!string.IsNullOrEmpty(searchModel.RegPlace))
                query = query.Where(h => h.Human.RegPlace.Contains(searchModel.RegPlace));

            if (!string.IsNullOrEmpty(searchModel.Job))
                query = query.Where(h => h.Human.Job.Contains(searchModel.Job));

            if (!string.IsNullOrEmpty(searchModel.BirthDate))
            {
                try
                {
                    var parts = searchModel.BirthDate.Split('/');
                    int year = int.Parse(parts[0]);
                    int month = int.Parse(parts[1]);
                    int day = int.Parse(parts[2]);
                    var pc = new PersianCalendar();
                    var miladiDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                    query = query.Where(h => h.Human.BirthDate.HasValue && h.Human.BirthDate.Value.Date == miladiDate.Date);
                }
                catch
                {
                    return BadRequest("فرمت تاریخ شمسی نادرست است. لطفاً به این صورت وارد کنید YYYY/MM/DD");
                }
            }

            if (searchModel.Sex.HasValue)
                query = query.Where(h => h.Human.Sex == searchModel.Sex.Value);

            if (!string.IsNullOrEmpty(searchModel.CreateDate))
            {
                try
                {
                    var parts = searchModel.CreateDate.Split('/');
                    int year = int.Parse(parts[0]);
                    int month = int.Parse(parts[1]);
                    int day = int.Parse(parts[2]);
                    var pc = new PersianCalendar();
                    var miladiDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                    query = query.Where(h => h.Human.CreateDate.HasValue && h.Human.CreateDate.Value.Date == miladiDate.Date);
                }
                catch
                {
                    return BadRequest("فرمت تاریخ شمسی نادرست است. لطفاً به این صورت وارد کنید YYYY/MM/DD");
                }
            }

            if (!string.IsNullOrEmpty(searchModel.Mobile))
                query = query.Where(h => h.Human.Mobile.Contains(searchModel.Mobile));

            if (searchModel.ClientId.HasValue)
                query = query.Where(h => h.Client.ClientId == searchModel.ClientId.Value);

            var humanClients = await query.Take(20).AsNoTracking().ToListAsync();

            var clientIds = humanClients.Select(h => h.Client.ClientId).ToList();

            var addressList = await _context.Addresses
                .Where(ad => clientIds.Contains(ad.ClientId)
                             && ad.AddressTypeId == 1
                             && ad.Active
                             && !string.IsNullOrEmpty(ad.Address1))
                .ToListAsync();

            var addressDict = addressList
                .GroupBy(ad => ad.ClientId)
                .ToDictionary(g => g.Key, g => g.First().Address1);


            var result = humanClients.Select(h =>
             {
                 addressDict.TryGetValue(h.Client.ClientId, out var address);

                 return new
                 {
                     h.Human.HumanId,
                     h.Human.HumanName,
                     h.Human.Family,
                     h.Human.FatherName,
                     h.Human.RegNo,
                     h.Human.NationalNo,
                     h.Human.RegPlace,
                     h.Human.Job,
                     BirthDate = h.Human.BirthDate.HasValue ? ToPersianDate(h.Human.BirthDate.Value) : "-",
                     CreateDate = h.Human.CreateDate.HasValue ? ToPersianDate(h.Human.CreateDate.Value) : "-",
                     Sex = h.Human.Sex ? "مرد" : "زن",
                     h.Human.Mobile,
                     h.Client.ClientId,
                     CustomerNo = h.Client.CustomerNo?.ToString(),
                     Address = address
                 };
             }).ToList();

            if (result.Count == 0)
                return NotFound("موردی با این مشخصات یافت نشد");

            return Ok(result);
        }



        /*/ Lambda With Dto for Search

        {
            var query = _context.Humans
                .Where(x => x.HumanId > 116991 && x.HumanId < 117012)
                .Join(_context.Clients,
                      h => h.HumanId,
                      c => c.RefId,
                      (h, c) => new { Human = h, Client = c })
                .Where(hc => hc.Client.Status == 1)
                .AsQueryable();

            if (searchModel.HumanId.HasValue)
                query = query.Where(h => h.Human.HumanId == searchModel.HumanId.Value);

            if (!string.IsNullOrEmpty(searchModel.HumanName))
                query = query.Where(h => h.Human.HumanName.ToLower().Contains(searchModel.HumanName.Trim().ToLower()));

            if (!string.IsNullOrEmpty(searchModel.Family))
                query = query.Where(h => h.Human.Family.Contains(searchModel.Family));

            if (!string.IsNullOrEmpty(searchModel.FatherName))
                query = query.Where(h => h.Human.FatherName.Contains(searchModel.FatherName));

            if (!string.IsNullOrEmpty(searchModel.RegNo))
                query = query.Where(h => h.Human.RegNo.Contains(searchModel.RegNo));

            if (!string.IsNullOrEmpty(searchModel.NationalNo))
                query = query.Where(h => h.Human.NationalNo.Contains(searchModel.NationalNo));

            if (!string.IsNullOrEmpty(searchModel.RegPlace))
                query = query.Where(h => h.Human.RegPlace.Contains(searchModel.RegPlace));

            if (!string.IsNullOrEmpty(searchModel.Job))
                query = query.Where(h => h.Human.Job.Contains(searchModel.Job));

            if (!string.IsNullOrEmpty(searchModel.BirthDate))
            {
                var miladiDate = TryParsePersianDate(searchModel.BirthDate);
                if (miladiDate == null)
                    return null;

                query = query.Where(h => h.Human.BirthDate.HasValue && h.Human.BirthDate.Value.Date == miladiDate.Value.Date);
            }

            if (searchModel.Sex.HasValue)
                query = query.Where(h => h.Human.Sex == searchModel.Sex.Value);

            if (!string.IsNullOrEmpty(searchModel.CreateDate))
            {
                var miladiDate = TryParsePersianDate(searchModel.CreateDate);
                if (miladiDate == null)
                    return null;

                query = query.Where(h => h.Human.CreateDate.HasValue && h.Human.CreateDate.Value.Date == miladiDate.Value.Date);
            }

            if (!string.IsNullOrEmpty(searchModel.Mobile))
                query = query.Where(h => h.Human.Mobile.Contains(searchModel.Mobile));

            if (searchModel.ClientId.HasValue)
                query = query.Where(h => h.Client.ClientId == searchModel.ClientId.Value);

            var humanClients = await query.Take(20).AsNoTracking().ToListAsync();

            var clientIds = humanClients.Select(h => h.Client.ClientId).ToList();

            var addressList = await _context.Addresses
                .Where(ad => clientIds.Contains(ad.ClientId)
                             && ad.AddressTypeId == 1
                             && ad.Active
                             && !string.IsNullOrEmpty(ad.Address1))
                .ToListAsync();

            var addressDict = addressList
                .GroupBy(ad => ad.ClientId)
                .ToDictionary(g => g.Key, g => g.First().Address1);

            var result = humanClients.Select(h =>
            {
                addressDict.TryGetValue(h.Client.ClientId, out var address);

                return new HumanSearchDto
                {
                    HumanId = h.Human.HumanId,
                    HumanName = h.Human.HumanName,
                    Family = h.Human.Family,
                    FatherName = h.Human.FatherName,
                    RegNo = h.Human.RegNo,
                    NationalNo = h.Human.NationalNo,
                    RegPlace = h.Human.RegPlace,
                    Job = h.Human.Job,
                    BirthDate = h.Human.BirthDate.HasValue ? ToPersianDate(h.Human.BirthDate.Value) : "-",
                    CreateDate = h.Human.CreateDate.HasValue ? ToPersianDate(h.Human.CreateDate.Value) : "-",
                    Sex = h.Human.Sex ? "مرد" : "زن",
                    Mobile = h.Human.Mobile,
                    ClientId = h.Client.ClientId,
                    CustomerNo = h.Client.CustomerNo?.ToString(),
                    Address = address
                };
            }).ToList();

            return result;
        }
        private DateTime? TryParsePersianDate(string persianDate)
        {
            try
            {
                var parts = persianDate.Split('/');
                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);
                var pc = new PersianCalendar();
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch
            {
                return null;
            }
        }
        */

        /*         //    Linq for search
       {
                var query = (
            from h in _context.Humans
            join c in _context.Clients on h.HumanId equals c.RefId
            where h.HumanId > 116991 && h.HumanId < 117012
                  && c.Status == 1
            select new { Human = h, Client = c }
            ).AsQueryable();

                // اعمال فیلترها
                if (searchModel.HumanId.HasValue)
                    query = query.Where(h => h.Human.HumanId == searchModel.HumanId.Value);

                if (!string.IsNullOrEmpty(searchModel.HumanName))
                    query = query.Where(h => h.Human.HumanName.ToLower().Contains(searchModel.HumanName.Trim().ToLower()));

                if (!string.IsNullOrEmpty(searchModel.Family))
                    query = query.Where(h => h.Human.Family.Contains(searchModel.Family));

                if (!string.IsNullOrEmpty(searchModel.FatherName))
                    query = query.Where(h => h.Human.FatherName.Contains(searchModel.FatherName));

                if (!string.IsNullOrEmpty(searchModel.RegNo))
                    query = query.Where(h => h.Human.RegNo.Contains(searchModel.RegNo));

                if (!string.IsNullOrEmpty(searchModel.NationalNo))
                    query = query.Where(h => h.Human.NationalNo.Contains(searchModel.NationalNo));

                if (!string.IsNullOrEmpty(searchModel.RegPlace))
                    query = query.Where(h => h.Human.RegPlace.Contains(searchModel.RegPlace));

                if (!string.IsNullOrEmpty(searchModel.Job))
                    query = query.Where(h => h.Human.Job.Contains(searchModel.Job));

                if (!string.IsNullOrEmpty(searchModel.BirthDate))
                {
                    try
                    {
                        var parts = searchModel.BirthDate.Split('/');
                        int year = int.Parse(parts[0]);
                        int month = int.Parse(parts[1]);
                        int day = int.Parse(parts[2]);
                        var pc = new PersianCalendar();
                        var miladiDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                        query = query.Where(h => h.Human.BirthDate.HasValue && h.Human.BirthDate.Value.Date == miladiDate.Date);
                    }
                    catch
                    {
                        return BadRequest("فرمت تاریخ شمسی نادرست است. لطفاً به این صورت وارد کنید YYYY/MM/DD");
                    }
                }

                if (searchModel.Sex.HasValue)
                    query = query.Where(h => h.Human.Sex == searchModel.Sex.Value);

                if (!string.IsNullOrEmpty(searchModel.CreateDate))
                {
                    try
                    {
                        var parts = searchModel.CreateDate.Split('/');
                        int year = int.Parse(parts[0]);
                        int month = int.Parse(parts[1]);
                        int day = int.Parse(parts[2]);
                        var pc = new PersianCalendar();
                        var miladiDate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                        query = query.Where(h => h.Human.CreateDate.HasValue && h.Human.CreateDate.Value.Date == miladiDate.Date);
                    }
                    catch
                    {
                        return BadRequest("فرمت تاریخ شمسی نادرست است. لطفاً به این صورت وارد کنید YYYY/MM/DD");
                    }
                }

                if (!string.IsNullOrEmpty(searchModel.Mobile))
                    query = query.Where(h => h.Human.Mobile.Contains(searchModel.Mobile));

                if (searchModel.ClientId.HasValue)
                    query = query.Where(h => h.Client.ClientId == searchModel.ClientId.Value);

                // اجرای نهایی
                var humanClients = await query.Take(20).AsNoTracking().ToListAsync();

                var clientIds = humanClients.Select(h => h.Client.ClientId).ToList();

                var addressList = await (
                    from a in _context.Addresses
                    where clientIds.Contains(a.ClientId)
                          && a.AddressTypeId == 1
                          && a.Active
                          && !string.IsNullOrEmpty(a.Address1)
                    select a
                ).ToListAsync();

                var addressDict = addressList
                    .GroupBy(ad => ad.ClientId)
                    .ToDictionary(g => g.Key, g => g.First().Address1);

                // خروجی
                var result = (
                    from h in humanClients
                    let address = addressDict.ContainsKey(h.Client.ClientId) ? addressDict[h.Client.ClientId] : null
                    select new
                    {
                        h.Human.HumanId,
                        h.Human.HumanName,
                        h.Human.Family,
                        h.Human.FatherName,
                        h.Human.RegNo,
                        h.Human.NationalNo,
                        h.Human.RegPlace,
                        h.Human.Job,
                        BirthDate = h.Human.BirthDate.HasValue ? ToPersianDate(h.Human.BirthDate.Value) : "-",
                        CreateDate = h.Human.CreateDate.HasValue ? ToPersianDate(h.Human.CreateDate.Value) : "-",
                        Sex = h.Human.Sex ? "مرد" : "زن",
                        h.Human.Mobile,
                        h.Client.ClientId,
                        CustomerNo = h.Client.CustomerNo?.ToString(),
                        Address = address
                    }
                ).ToList();

                if (result.Count == 0)
                    return NotFound("موردی با این مشخصات یافت نشد");

                return Ok(result);

         }
    */



        /* Include for Search
     * 
     var query = _context.Humans
.Include(h => h.Client)
    .ThenInclude(c => c.Addresses)
.Where(h => h.HumanId > 116991 && h.HumanId < 117012)
.AsQueryable();

// اعمال فیلترهای جستجو مثل قبل...

// بعد از فیلتر، گرفتن خروجی:
var result = await query.Take(20).AsNoTracking().ToListAsync();

var dtoList = result.Select(h =>
{
var address = h.Client?.Addresses
    .Where(a => a.AddressTypeId == 1 && a.Active && !string.IsNullOrEmpty(a.Address1))
    .OrderBy(a => a.Id)
    .Select(a => a.Address1)
    .FirstOrDefault();

return new HumanReportDto
{
    HumanId = h.HumanId,
    HumanName = h.HumanName,
    Family = h.Family,
    FatherName = h.FatherName,
    RegNo = h.RegNo,
    NationalNo = h.NationalNo,
    RegPlace = h.RegPlace,
    Job = h.Job,
    BirthDate = ToPersianDate(h.BirthDate),
    CreateDate = ToPersianDate(h.CreateDate),
    Sex = h.Sex,
    Mobile = h.Mobile,
    ClientId = h.Client?.ClientId ?? 0,
    CustomerNo = h.Client?.CustomerNo?.ToString(),
    Address = address
};
}).ToList();

     */


    }

}

