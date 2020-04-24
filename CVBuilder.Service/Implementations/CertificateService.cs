using System.Collections.Generic;
using CVBuilder.Repository.DTOs;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Service.Helpers;
using CVBuilder.Service.Interfaces;

namespace CVBuilder.Service.Implementations
{
    public class CertificateService : UnitOfWork, IService<CertificateDTO>
    {
        public CertificateService(IUnitOfWorkRepository unitOfWork) : base(unitOfWork)
        {
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

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IEnumerable<CertificateDTO> allCertificates = _UnitOfWork.Certificate.GetAll(curriculumId);
            List<SummaryBlockDTO> certificateBlocks = new List<SummaryBlockDTO>();

            foreach (CertificateDTO certificate in allCertificates)
            {
                certificateBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = certificate.CertificateId,
                    Title = certificate.Name,
                    StateInTime = certificate.InProgress ? "(" + GlobalVariables.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
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
                StateInTime = (certificate.InProgress) ? "(" + GlobalVariables.CERTIFICATE_INPROGRESS_TEXT + ")" : "(" + certificate.Year.ToString() + ")",
                IsVisible = certificate.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _UnitOfWork.Certificate.ToggleVisibility("CertificatesIsVisible", curriculumId);
        }
    }
}