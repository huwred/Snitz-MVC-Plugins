using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PetaPoco;
using Snitz.Base;
using SnitzDataModel.Validation;

namespace MemberFields.Models
{
    [TableName("USERFIELDS", prefixType = Extras.TablePrefixTypes.Member)]
    [PrimaryKey("USR_FIELD_ID")]
    [ExplicitColumns]
    public class ExtendedProfile
    {
        [Column("USR_FIELD_ID")]
        public int Id { get; set; }

        [Column("USR_SHORTNAME")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string FieldName { get; set; }

        [Column("USR_DESC")]
        public string Description { get; set; }

        [Column("USR_DEFAULT")]
        public string DefaultValue { get; set; }

        [Column("USR_VALUES")]
        public string OptionsString { get; set; }

        /// <summary>
        /// S = Simple Input
        /// N = Number Input
        /// T = Text Area
        /// C = Check Box
        /// D = Date
        /// X = Time
        /// Z = DateTime
        /// O = Select Box
        /// M = Multi-Select Box
        /// H = Horizontal Radio Buttons
        /// V = Vertical Radio Buttons
        /// </summary>
        [Column("USR_FIELDTYPE")]
        [UIHint("FieldType")]
        public string FieldType { get; set; }

        [Column("USR_OPTIONAL")]
        [UIHint("YesNoShort")]
        public short Optional { get; set; }

        [Column("USR_PRIVATE")]
        [UIHint("YesNoShort")]
        public short Private { get; set; }


        public List<string> Options
        {
            get { return this.OptionsString.Split('|').ToList(); }
        }
    }


    [TableName("MEMBERFIELDS", prefixType = Extras.TablePrefixTypes.Member)]
    [PrimaryKey("MEMBER_ID,USR_FIELD_ID", AutoIncrement = false)]
    [ExplicitColumns]
    public class MemberProfile
    {
        [Column("MEMBER_ID")]
        public int MemberId { get; set; }
        [Column("USR_FIELD_ID")]
        public int PropertyId { get; set; }

        [Column("USR_VALUE")]
        [RequiredIf("Optional", 0, "PropertyRequired")]
        public string PropertyValue { get; set; }

        [ResultColumn]
        public string PropertyName { get; set; }
        [ResultColumn]
        public string PropertyType { get; set; }
        [ResultColumn]
        [UIHint("YesNoShort")]
        public short Private { get; set; }
        [ResultColumn]
        [UIHint("YesNoShort")]
        public short Optional { get; set; }

        public List<string> PropertyOptions
        {
            get
            {
                var fieldProps = MemberFieldsRepository.GetProperty(this.PropertyName);
                return fieldProps.Options;
            }
        }
    }

}
