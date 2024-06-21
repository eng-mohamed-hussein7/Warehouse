using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Repositories.PurchaseInvoiceRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models.PurchaseInvoice;

namespace BusinessLogicLayer.Services.PurchaseInvoiceServices
{
    public class PurchaseInvoiceService : IPurchaseInvoiceService
    {
        private readonly IPurchaseInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public PurchaseInvoiceService(IPurchaseInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseInvoiceDTO>> GetAllAsync()
        {
            var invoiceHeads = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PurchaseInvoiceDTO>>(invoiceHeads);
        }

        public async Task<PurchaseInvoiceDTO> GetByIdAsync(int id)
        {
            var invoiceHead = await _repository.GetByIdAsync(id);
            return _mapper.Map<PurchaseInvoiceDTO>(invoiceHead);
        }

        public async Task AddAsync(PurchaseInvoiceDTO invoiceDto)
        {
            PurchaseInvoiceHead purchaseInvoiceHead = new PurchaseInvoiceHead()
            {
                DateOfAddition = DateTime.Now,
                InvoiceNumber = invoiceDto.InvoiceNumber,
                SupplierName = invoiceDto.SupplierName,
                IsDeleted = false,

            };
            List<PurchaseInvoiceDetail> purchaseInvoiceDetail = new List<PurchaseInvoiceDetail>();

            foreach (var item in invoiceDto.PurchaseInvoiceDetails)
            {
                PurchaseInvoiceDetail invoiceDetail = new PurchaseInvoiceDetail()
                {
                    Product_ID = item.Product_ID,
                    DateOfAddition = DateTime.Now,
                    IsDeleted=false,
                    ResivedQuantity = item.ResivedQuantity,
                    //PurchaseInvoiceHead_ID = purchaseInvoiceHead.Id,
                    };
                purchaseInvoiceDetail.Add(invoiceDetail);
            }
            await _repository.AddAsync(purchaseInvoiceHead , purchaseInvoiceDetail);
        }

        public async Task UpdateAsync(PurchaseInvoiceDTO invoiceDto)
        {
            var invoiceHead = _mapper.Map<PurchaseInvoiceHead>(invoiceDto);
            await _repository.UpdateAsync(invoiceHead);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
