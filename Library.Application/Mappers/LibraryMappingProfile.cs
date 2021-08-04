using AutoMapper;
using Library.Application.DTO;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Mappers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {            
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author_Book, Author_BookDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book_category, Book_categoryDTO>().ReverseMap();
            CreateMap<Book_tag, Book_tagDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Reader, ReaderDTO>().ReverseMap();
            CreateMap<Shelf, ShelfDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
        }
    }
}
