using AutoMapper;
using System.Linq;
using Library.Application.Dto;
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
            #region Create
           CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorBook, AuthorBookDTO>().ConstructUsing(i => new AuthorBookDTO
            {
                Id = i.Id,
                AuthorName = i.AuthorsObj.FullName,
                AuthorId = i.AuthorId,
                BookTitle = i.BooksObj.Title,
                BookId = i.BookId
            });
            CreateMap<Book, BookDTO>().ConstructUsing(i => new BookDTO
            {
                Id = i.Id,
                PhotoPath = i.PhotoPath,                
                TakeDate = i.TakeDate,
                Title = i.Title,
                ShelfId = i.ShelfId,
                ShelfName = i.ShelfObj.Name,
                ReaderId = i.ReaderId,
                ReaderName = i.ReaderObj.FullName            
            });
            CreateMap<BookCategory, BookCategoryDTO>().ConstructUsing(i => new BookCategoryDTO
            {
                Id = i.Id,                
                BookId = i.BookId,
                BookTitle = i.BookObj.Title,                
                CategoryId = i.CategoryId,
                CategoryName = i.CategoryObj.Name                
            }); 
            CreateMap<BookTag, BookTagDTO>().ConstructUsing(i => new BookTagDTO
            {
                Id = i.Id,
                BookTitle = i.BookObj.Title,
                BookId = i.BookId,
                TagName = i.TagObj.Name,
                TagId = i.TagId
            });
            CreateMap<Category, CategoryDTO>().ConstructUsing(i => new CategoryDTO
            {
                Id = i.Id,
                Name = i.Name               
            });
            CreateMap<Reader, ReaderDTO>().ConstructUsing(i => new ReaderDTO
            {
                Id = i.Id,
                BirthDate = i.BirthDate,
                RegistrationDate = i.RegistrationDate,                
                FullName = i.FullName
            });
            CreateMap<Shelf, ShelfDTO>().ConstructUsing(i => new ShelfDTO
            {
                Id = i.Id,
                Name = i.Name
            });
            CreateMap<Tag, TagDTO>().ConstructUsing(i => new TagDTO
            {
                Id = i.Id,
                Name = i.Name
            }); 
            #endregion  
            //CreateMap<Book, BookDTO>()
            //    .ForMember(dest => dest.ShelfDTOObj, opt => opt.MapFrom(src => src.ShelfObj))
            //    .ForMember(dest => dest.ReaderDTOObj, opt => opt.MapFrom(src => src.ReaderObj));
            //CreateMap<Shelf, ShelfDTO>();
            //CreateMap<Reader, ReaderDTO>();
            //CreateMap<BookDTO, Book>()
            //   .ForMember(dest => dest.ShelfObj, opt => opt.MapFrom(src => src.ShelfDTOObj))
            //   .ForMember(dest => dest.ReaderObj, opt => opt.MapFrom(src => src.ReaderDTOObj));
            //CreateMap<ShelfDTO, Shelf>();
            //CreateMap<ReaderDTO, Reader>();
        }
    }
}
