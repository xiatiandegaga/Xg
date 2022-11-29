﻿// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityMap
{
    public class UserMap
           : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // table
            builder.ToTable("sys_user");


            // Properties
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.Property(t => t.Account)
                .HasColumnName("Account")
                .HasMaxLength(320)
                .IsRequired();
            builder.Property(t => t.Password)
                .HasColumnName("Password")
                .HasMaxLength(400)
                ;
            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(80)
                .IsRequired();
            builder.Property(t => t.Mobile)
                .HasColumnName("Mobile")
                .HasMaxLength(80)
                ;
            builder.Property(t => t.Img)
                .HasColumnName("Img")
                .HasMaxLength(800)
                ;
            builder.Property(t => t.ThirdpartId)
                .HasColumnName("ThirdpartId")
                .HasMaxLength(200)
                ;
            builder.Property(t => t.MachingCode)
                .HasColumnName("MachingCode")
                .HasMaxLength(200)
                ;
            builder.Property(t => t.MemberCtgrId)
                .HasColumnName("MemberCtgrId")
                .IsRequired();
            builder.Property(t => t.MemberPoint)
                .HasColumnName("MemberPoint")
                .IsRequired();
            builder.Property(t => t.IsActivate)
                .HasColumnName("IsActivate")
                .IsRequired();
            builder.Property(t => t.IsVerifyPhone)
                .HasColumnName("IsVerifyPhone")
                .IsRequired();
            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .IsRequired();
            builder.Property(t => t.CreateDate)
                .HasColumnName("CreateDate")
                .IsRequired();
            builder.Property(t => t.CreateId)
                .HasColumnName("CreateId")
                .IsRequired();
            builder.Property(t => t.Sex)
                .HasColumnName("Sex")
                .IsRequired();
            builder.Property(t => t.SignInCount)
                .HasColumnName("SignInCount")
                .IsRequired();
            builder.Property(t => t.SignInDate)
                .HasColumnName("SignInDate")
                ;
            builder.Property(t => t.MemberLevel)
                .HasColumnName("MemberLevel")
                .IsRequired();
            builder.Property(t => t.BirthDay)
                .HasColumnName("BirthDay")
                ;
            builder.Property(t => t.GiveBirthPoint)
                .HasColumnName("GiveBirthPoint")
                .IsRequired();
            builder.Property(t => t.PointRedeemNum)
                .HasColumnName("PointRedeemNum")
                .HasColumnType("decimal(9, 4)")
                .IsRequired();
            builder.Property(t => t.WorkUnitCode)
                .HasColumnName("WorkUnitCode")
                .HasMaxLength(200)
                ;
            builder.Property(t => t.IsBlack)
                .HasColumnName("IsBlack")
                .IsRequired();
            builder.Property(t => t.HobbyGroup)
                .HasColumnName("HobbyGroup")
                .HasMaxLength(500);

            builder.Property(t => t.EntryDate)
                .HasColumnName("EntryDate");
            builder.Property(t => t.DeptId)
             .HasColumnName("DeptId").IsRequired();

            builder.Property(t => t.Pid)
           .HasColumnName("Pid").IsRequired();
            builder.Property(t => t.ReferId)
            .HasColumnName("ReferId").IsRequired();

            builder.Property(t => t.NickName)
           .HasColumnName("NickName").HasMaxLength(50);
            builder.Property(t => t.GiveEntryPoint)
             .HasColumnName("GiveEntryPoint")
             .IsRequired();
            builder.Property(t => t.SourceFrom)
           .HasColumnName("SourceFrom").IsRequired();
            builder.Property(t => t.UpdateSalesConsultantDate)
           .HasColumnName("UpdateSalesConsultantDate");
            builder.Property(t => t.SceneSignInCount)
           .HasColumnName("SceneSignInCount")
           .IsRequired();
            builder.Property(t => t.FieldId)
           .HasColumnName("FieldId")
           .IsRequired();
            builder.Property(t => t.UserPermissions)
            .HasColumnName("UserPermissions")
            .HasMaxLength(100);
            builder.Property(t => t.FirstFieldId)
          .HasColumnName("FirstFieldId")
          .IsRequired();
            builder.Property(t => t.GiveBirthCoupon)
                .HasColumnName("GiveBirthCoupon")
                .IsRequired();
            builder.Property(t => t.BlindBboxCount)
               .HasColumnName("BlindBboxCount")
               .IsRequired();
            builder.Property(t => t.UserLabel)
           .HasColumnName("UserLabel")
           .HasMaxLength(400);

            builder.Property(t => t.PostersType)
           .HasColumnName("PostersType")
           .HasMaxLength(400);

            builder.Property(t => t.PostersKey)
             .HasColumnName("PostersKey")
             .IsRequired();

            builder.Property(t => t.Address)
            .HasColumnName("Address")
            .HasMaxLength(1000);

            builder.Property(t => t.Email)
            .HasColumnName("Email")
            .HasMaxLength(1000);


            builder.Property(t => t.XjShopId)
            .HasColumnName("XjShopId")
            .IsRequired();
            builder.Property(t => t.ShopId)
        .HasColumnName("ShopId")
        .IsRequired();
            builder.Property(t => t.XjPoint)
            .HasColumnName("XjPoint")
            .IsRequired();
            builder.Property(t => t.XjBlindBboxCount)
           .HasColumnName("XjBlindBboxCount")
           .IsRequired();

            builder.Property(t => t.AuthDate)
            .HasColumnName("AuthDate");
            builder.Property(t => t.KsdShopId)
     .HasColumnName("KsdShopId")
     .IsRequired();
            builder.Property(t => t.Unionid)
            .HasColumnName("Unionid");
        }
    }
}
