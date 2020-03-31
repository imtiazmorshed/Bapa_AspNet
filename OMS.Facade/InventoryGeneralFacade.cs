using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IInventoryGeneralFacade
    {
        List<MeasurementUnit> GetMeasurementUnitAll();
        MeasurementUnit GetMeasurementUnitByID(int id);

        void Dispose();
    }
    class InventoryGeneralFacade: BaseFacade, IInventoryGeneralFacade
    {
        public InventoryGeneralFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IInventoryGeneralFacade Members

        List<MeasurementUnit> IInventoryGeneralFacade.GetMeasurementUnitAll()
        {
            List<MeasurementUnit> measurementUnitList = new List<MeasurementUnit>();
            measurementUnitList = Database.MeasurementUnits.Where(m => m.IsRemoved == 0).ToList();
            return measurementUnitList;
        }

        MeasurementUnit IInventoryGeneralFacade.GetMeasurementUnitByID(int id)
        {
            MeasurementUnit measurementUnit = new MeasurementUnit();
            measurementUnit = Database.MeasurementUnits.Single(m => m.IID == id && m.IsRemoved == 0);
            return measurementUnit;
        }

        

        #endregion

        
    }
}
