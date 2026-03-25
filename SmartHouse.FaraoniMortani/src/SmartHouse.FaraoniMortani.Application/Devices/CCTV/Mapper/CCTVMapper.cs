using SmartHouse.FaraoniMortani.Application.Devices.Abstractions.Mapper;
using SmartHouse.FaraoniMortani.Application.Devices.CCTV.DTO;
using SmartHouse.FaraoniMortani.Domain.Devices.Abstractions;
using SmartHouse.FaraoniMortani.Domain.Devices.CCTV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.FaraoniMortani.Application.Devices.CCTV.Mapper
{
    public class CCTVMapper
    {
        public static CCTVDto ToDto(Domain.Devices.CCTV.CCTV cctv)
        {
            return new CCTVDto
            {
                Id = cctv.Id,
                Name = cctv.Name,
                Status = DeviceStatusMapper.ToDto(cctv.Status),
                Mode = cctv.Mode,
                Inclination = cctv.InclinationValue,
                Zoom = cctv.CurrentZoom,
                CreatedAtUtc = cctv.CreationTime,
                LastModifiedAtUtc = cctv.LastChangeTime,
            };
        }
    }
}
