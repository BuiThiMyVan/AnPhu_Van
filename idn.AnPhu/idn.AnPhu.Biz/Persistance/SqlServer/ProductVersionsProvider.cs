using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class ProductVersionsProvider : DataAccessBase, IProductVersionsProvider
    {
        public ProductVersions Get(ProductVersions dummy)
        {
            DbCommand comm = this.GetCommand("Sp_ProductVersions_GetById");

            comm.AddParameter<int>(this.Factory, "versionId", dummy.VersionId);

            var table = this.GetTable(comm);
            table.TableName = TableName.ProductVersions;
            var test = EntityBase.ParseListFromTable<ProductVersions>(table).FirstOrDefault();
            return EntityBase.ParseListFromTable<ProductVersions>(table).FirstOrDefault();
        }

        public List<ProductVersions> GetAllVersions(int productId, int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_ProductVersions_GetAll");
            comm.AddParameter<int>(this.Factory, "productId", productId);
            var table = this.GetTable(comm);
            table.TableName = TableName.ProductVersions;
            return EntityBase.ParseListFromTable<ProductVersions>(table);
        }

        public List<ProductVersions> Search(int productId, string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_ProductVersions_Search");
            comm.AddParameter<int>(this.Factory, "productId", productId);
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.ProductVersions;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<ProductVersions>(table);
        }

        public void Add(ProductVersions item)
        {
            DbCommand comm = this.GetCommand("Sp_ProductVersions_Create");

            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<string>(this.Factory, "VersionTitle", (item.VersionTitle != null && item.VersionTitle.Trim().Length > 0) ? item.VersionTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "VersionCode", (item.VersionCode != null && item.VersionCode.Trim().Length > 0) ? item.VersionCode.Trim() : null);
            comm.AddParameter<int>(this.Factory, "VersionPrice", item.VersionPrice);
            comm.AddParameter<string>(this.Factory, "VersionDescription", (item.VersionDescription != null && item.VersionDescription.Trim().Length > 0) ? item.VersionDescription.Trim() : null);
            comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
            comm.AddParameter<int>(this.Factory, "RegistrationFeeHN", item.RegistrationFeeHN);
            comm.AddParameter<int>(this.Factory, "LicenseFeeHN", item.LicenseFeeHN);
            comm.AddParameter<int>(this.Factory, "RoadTaxHN", item.RoadTaxHN);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeHN", item.InsuranceFeeHN);
            comm.AddParameter<int>(this.Factory, "RegistrationFeeHCM", item.RegistrationFeeHCM);
            comm.AddParameter<int>(this.Factory, "LicenseFeeHCM", item.LicenseFeeHCM);
            comm.AddParameter<int>(this.Factory, "CertificateFeeHCM", item.CertificateFeeHCM);
            comm.AddParameter<int>(this.Factory, "RoadTaxHCM", item.RoadTaxHCM);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeHCM", item.InsuranceFeeHCM);
            comm.AddParameter<int>(this.Factory, "RegistrationFeeKHAC", item.RegistrationFeeKHAC);
            comm.AddParameter<int>(this.Factory, "LicenseFeeKHAC", item.LicenseFeeKHAC);
            comm.AddParameter<int>(this.Factory, "RoadTaxKHAC", item.RoadTaxKHAC);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeKHAC", item.InsuranceFeeKHAC);
            comm.AddParameter<int>(this.Factory, "CertificateFeeKHAC", item.CertificateFeeKHAC);
            comm.AddParameter<int>(this.Factory, "CertificateFeeHN", item.CertificateFeeHN);
            comm.AddParameter<bool>(this.Factory, "IsRegister", item.IsRegister);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public void Update(ProductVersions @new, ProductVersions old)
        {
            var item = @new;
            item.VersionId = old.VersionId;
            var comm = this.GetCommand("Sp_ProductVersions_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VersionId", item.VersionId);
            comm.AddParameter<string>(this.Factory, "VersionTitle", (item.VersionTitle != null && item.VersionTitle.Trim().Length > 0) ? item.VersionTitle.Trim() : null);
            comm.AddParameter<string>(this.Factory, "VersionCode", (item.VersionCode != null && item.VersionCode.Trim().Length > 0) ? item.VersionCode.Trim() : null);
            comm.AddParameter<int>(this.Factory, "VersionPrice", item.VersionPrice);
            comm.AddParameter<string>(this.Factory, "VersionDescription", (item.VersionDescription != null && item.VersionDescription.Trim().Length > 0) ? item.VersionDescription.Trim() : null);           
            comm.AddParameter<int>(this.Factory, "RegistrationFeeHN", item.RegistrationFeeHN);
            comm.AddParameter<int>(this.Factory, "LicenseFeeHN", item.LicenseFeeHN);
            comm.AddParameter<int>(this.Factory, "RoadTaxHN", item.RoadTaxHN);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeHN", item.InsuranceFeeHN);
            comm.AddParameter<int>(this.Factory, "RegistrationFeeHCM", item.RegistrationFeeHCM);
            comm.AddParameter<int>(this.Factory, "LicenseFeeHCM", item.LicenseFeeHCM);
            comm.AddParameter<int>(this.Factory, "CertificateFeeHCM", item.CertificateFeeHCM);
            comm.AddParameter<int>(this.Factory, "RoadTaxHCM", item.RoadTaxHCM);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeHCM", item.InsuranceFeeHCM);
            comm.AddParameter<int>(this.Factory, "RegistrationFeeKHAC", item.RegistrationFeeKHAC);
            comm.AddParameter<int>(this.Factory, "LicenseFeeKHAC", item.LicenseFeeKHAC);
            comm.AddParameter<int>(this.Factory, "RoadTaxKHAC", item.RoadTaxKHAC);
            comm.AddParameter<int>(this.Factory, "InsuranceFeeKHAC", item.InsuranceFeeKHAC);
            comm.AddParameter<int>(this.Factory, "CertificateFeeKHAC", item.CertificateFeeKHAC);
            comm.AddParameter<int>(this.Factory, "CertificateFeeHN", item.CertificateFeeHN);
            comm.AddParameter<bool>(this.Factory, "IsRegister", item.IsRegister);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

            this.SafeExecuteNonQuery(comm);
        }

        public List<ProductVersions> GetAll(int startIndex, int count, ref int totalItems)
        {
            var result = new List<ProductVersions>();
            return result;
        }

        public List<ProductVersions> Search(int startIndex, int count, ref int totalItems)
        {
            var result = new List<ProductVersions>();
            return result;
        }

        public void Remove(ProductVersions item)
        {
            var comm = this.GetCommand("Sp_ProductVersions_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VersionId", item.VersionId);
            this.SafeExecuteNonQuery(comm);
        }

        public void Import(List<ProductVersions> list, bool deleteExist)
        {
        }
    }
}
