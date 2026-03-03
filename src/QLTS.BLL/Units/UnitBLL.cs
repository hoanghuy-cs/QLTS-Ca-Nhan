using QLTS.DAL.Units;
using QLTS.DTO.Models;
using System.Collections.Generic;

namespace QLTS.BLL.Units
{
    public class UnitBLL
    {
        private readonly UnitDAL _unitDAL = new UnitDAL();

        public List<Unit> GetUnits()
        {
            return _unitDAL.GetUnits();
        }
    }
}
