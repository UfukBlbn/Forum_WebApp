using BlazorForum.Api.Domain.Models;
using BlazorForum.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Infrastructure.Persistence.EntityConfiguration.EntryComment;

public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
{
    public virtual void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entrycommentfavorite", BlazorForumContext.DEFAULT_SCHEMA);
        builder.HasOne(i => i.EntryComment)
            .WithMany(i => i.EntryCommentFavorites)
            .HasForeignKey(i => i.EntryCommentId);

        builder.HasOne(i => i.CreatedUser)
            .WithMany(i => i.EntryCommentFavorites)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);



    }
}
