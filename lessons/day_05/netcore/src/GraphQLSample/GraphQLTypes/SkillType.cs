﻿using GraphQL.Types;
using GraphQLNetCore.Models;
using GraphQLNetCore.Repositories;

namespace GraphQLNetCore.GraphQLTypes
{
   public class SkillType : ObjectGraphType<Skill>
   {
      public SkillType(ISkillRepository repo)
      {
         Name = nameof(Skill);
         Field(_ => _.Id, type: typeof(IdGraphType));
         Field(_ => _.Name);
         Field<SkillType>(nameof(Skill.Parent), resolve: context => repo.Get(InputSkill.FromId(context.Source.ParentId)));
      }
   }
}
