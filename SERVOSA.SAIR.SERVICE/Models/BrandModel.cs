using SERVOSA.SAIR.DATAACCESS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class BrandModel
    {
        public string ConcatenatedCode { get; set; }
        public string TableCode { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public static void ToServiceModel(BrandDataModel dataModel, ref BrandModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new BrandModel()
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

        public static void ToDataModel(BrandModel serviceModel, ref BrandDataModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new BrandDataModel()
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
