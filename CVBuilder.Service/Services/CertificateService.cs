using System.Collections.Generic;
using CVBuilder.Core;
using CVBuilder.Core.DTOs;
using CVBuilder.Core.Services;
using CVBuilder.Service.Helpers;

namespace CVBuilder.Service.Services
{
    public class CertificateService : ISectionService<CertificateDTO>
    {
        protected readonly IUnitOfWork _UnitOfWork;

        public CertificateService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int Create(CertificateDTO dto)
        {
            return _UnitOfWork.Certificate.Create(dto);
        }

        public void Update(CertificateDTO dto)
        {
            _UnitOfWork.Certificate.Update(dto, nameof(dto.CertificateId));
        }

        public int Delete(int id)
        {
            return _UnitOfWork.Certificate.Delete(id);
        }

        public CertificateDTO GetById(int id)
        {
            return _UnitOfWork.Certificate.GetById(id);
        }

        public IEnumerable<CertificateDTO> GetAll(int curriculumId)
        {
            return _UnitOfWork.Certificate.GetAll(curriculumId);
        }

        public IEnumerable<CertificateDTO> GetAllVisible(int curriculumId)
        {
            return _UnitOfWork.Certificate.GetAllVisible(curriculumId);
        }

        public List<SummaryBlockDTO> GetSummaryBlocks(int curriculumId)
        {
            IEnumerable<CertificateDTO> allCertificates = _UnitOfWork.Certificate.GetAll(curriculumId);
            List<SummaryBlockDTO> certificateBlocks = new List<SummaryBlockDTO>();

            foreach (CertificateDTO certificate in allCertificates)
            {
                certificateBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = certificate.CertificateId,
                    Title = certificate.Name,
                    TimePeriod = certificate.InProgress ? "(" + GlobalVariables.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
                    IsVisible = certificate.IsVisible
                });
            }

            return certificateBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            CertificateDTO certificate;

            if (id > 0)
                certificate = _UnitOfWork.Certificate.GetById(id);
            else
                certificate = _UnitOfWork.Certificate.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = certificate.CertificateId,
                Title = certificate.Name,
                TimePeriod = (certificate.InProgress) ? "(" + GlobalVariables.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
                IsVisible = certificate.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Certificate.ToggleVisibility("CertificatesIsVisible", curriculumId);
        }
    }
}