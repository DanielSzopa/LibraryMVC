﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Domain.Interfaces;
using System.Linq;

namespace LibraryMVC.Application
{
    public class TypeOfBookService : ITypeOfBookService
    {
        private readonly ITypeOfBookRepository _typeOfBookRepository;
        private readonly IMapper _mapper;
        public TypeOfBookService(ITypeOfBookRepository typeOfBookRepository, IMapper mapper)
        {
            _typeOfBookRepository = typeOfBookRepository;
            _mapper = mapper;
        }
        public TypeOfBookListVm GetAllTypeOfBooksToList()
        {
            var typeOfBooks = _typeOfBookRepository.GetAllTypeOfBooks().ProjectTo<TypeOfBookVm>(_mapper.ConfigurationProvider)
               .ToList();

            var result = new TypeOfBookListVm
            {
                TypesOfBooks = typeOfBooks
            };

            return result;
        }
    }
}