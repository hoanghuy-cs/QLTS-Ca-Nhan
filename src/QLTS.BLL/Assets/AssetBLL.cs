using QLTS.DAL.Assets;
using QLTS.DTO.DTOs;
using QLTS.DTO.Models;
using System.Collections.Generic;

namespace QLTS.BLL.Assets
{
    public class AssetBLL
    {
        private readonly AssetDAL _assetDAL = new AssetDAL();

        public List<AssetItemDTO> GetAssets(AssetFilter filter = null)
        {
            if (filter == null)
            {
                filter = new AssetFilter();
            }

            if (!string.IsNullOrWhiteSpace(filter.Keyword))
            {
                filter.Keyword = filter.Keyword.Trim();
            }

            return _assetDAL.GetAssets(
                keyword: filter.Keyword,
                quantityType: filter.QuantityType);
        }

        public int Create(Asset asset)
        {
            return _assetDAL.Create(asset);
        }

        public int Update(Asset asset)
        {
            return _assetDAL.Update(asset);
        }

        public void Delete(int id)
        {
            _assetDAL.Delete(id);
        }
    }
}
