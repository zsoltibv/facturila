﻿using FacturilaAPI.Models.Dto;
using FacturilaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FacturilaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet("GetUserFirmBankAccounts/{userId}")]
        public async Task<ActionResult<FirmDto>> GetUserFirmBankAccounts(Guid userId)
        {
            var bankAccountDto = await _bankAccountService.GetUserFirmBankAccounts(userId);
            return Ok(bankAccountDto);
        }

        [HttpPut("AddOrEditBankAccount/{userId}")]
        public async Task<ActionResult<FirmDto>> AddOrEditBankAccount(BankAccountDto bankAccountDto, Guid userId)
        {
            try
            {
                var updatedOrNewBankAccount = await _bankAccountService.AddOrEditBankAccount(bankAccountDto, userId);
                return Ok(updatedOrNewBankAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
