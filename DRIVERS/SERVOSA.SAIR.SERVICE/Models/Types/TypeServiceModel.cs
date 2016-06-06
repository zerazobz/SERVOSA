using SERVOSA.SAIR.DATAACCESS.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.Types
{
    public class TypeServiceModel
    {
        public string ConcatenatedCode { get; set; }
        public string TableCode { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public static void ToServiceModel(DriverTypeModel dataModel, ref TypeServiceModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new TypeServiceModel()
                {
                    ConcatenatedCode = dataModel.TYPE_CodeConcatenated,
                    Description = dataModel.TYPE_cDescription,
                    Notes = dataModel.TYPE_cNotes,
                    TableCode = dataModel.TYPE_cCodTable,
                    TypeCode = dataModel.TYPE_cCodType
                };
            else
                serviceModel = null;
        }

        public static void ToDataModel(TypeServiceModel serviceModel, ref DriverTypeModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new DriverTypeModel()
                {
                    TYPE_cCodTable = serviceModel.TableCode,
                    TYPE_cCodType = serviceModel.TypeCode,
                    TYPE_cDescription = serviceModel.Description,
                    TYPE_cNotes = serviceModel.Notes,
                    TYPE_CodeConcatenated = serviceModel.Description
                };
            else
                dataModel = null;
        }
    }
}
