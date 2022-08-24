using HairdresserSalon.Data;
using HairdresserSalon.Models;
using HairdresserSalon.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserSalon.Repositories.Concrete
{
    public class InformationRepository : IInformationRepository
    {
        private readonly HairdresserDbContext _context;
        public InformationRepository(HairdresserDbContext context)
        {
            _context = context;
        }
        public async Task<InformationModel> GetInformation()
        {
            return await _context.Informations.Include(x => x.OpeningHour).FirstOrDefaultAsync();
        }

        public async Task Update(InformationModel informationModel)
        {
            var result = _context.Informations.SingleOrDefault(x => x.Id == informationModel.Id);
            if (result!=null)
            {
                result.Street = informationModel.Street;
                result.City = informationModel.City;
                result.PhoneNumber = informationModel.PhoneNumber;
                await _context.SaveChangesAsync();
            }
        }
    }
}
