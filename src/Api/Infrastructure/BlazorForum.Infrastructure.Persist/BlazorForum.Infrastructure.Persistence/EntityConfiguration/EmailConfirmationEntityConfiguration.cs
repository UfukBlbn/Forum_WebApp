using BlazorForum.Api.Domain.Models;
using BlazorForum.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Infrastructure.Persistence.EntityConfiguration
{
    public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
    {
        public virtual void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", BlazorForumContext.DEFAULT_SCHEMA);
          

        }
    }
}
