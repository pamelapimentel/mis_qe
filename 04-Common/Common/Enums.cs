using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public class Enums
    {
        public enum EntityType
        {
            Leads,
            Opportunities,
            Quotes
        }

        public enum IncomeType
        {
            Total,
            CompanyTotal,
            TeacherTotal
        }

        public enum PanelMenu
        {
            Resumen,
            Perfil,
            Cuenta,
            Lead,
            Oportunidades,
            Tareas
        }

        public enum Gender
        {
            [Description("Masculino")]
            Male,
            [Description("Femenino")]
            Female
        }

        public enum Status
        {
            Enable,
            Disable
        }

        public enum MyFilters
        {
            IsDeleted
        }

        // new enums
        public enum Industry
        {
            [Description("Minería")]
            Mineria,
            [Description("Oil & Gas")]
            OilyGas,
            Retail,
            Telecom,
            Turismo,
            Industrial,
            Rural,
            Servicios,
            Interconectado
        }

        public enum Sector
        {
            [Description("Público")]
            Publico,
            Privado
        }

        public enum StatusUser
        {
            Enable,
            Disable
        }

        public enum StatusLead
        {
            Califica,
            [Description("No Califica")]
            NoCalifica
        }

        public enum RankingLead
        {
            Alto,
            Medio,
            Bajo
        }

        public enum ProbabilityOpportunity
        {
            [Description("0%")]
            porcentaje0,
            [Description("10%")]
            porcentaje10,
            [Description("20%")]
            porcentaje20,
            [Description("30%")]
            porcentaje30,
            [Description("40%")]
            porcentaje40,
            [Description("50%")]
            porcentaje50,
            [Description("60%")]
            porcentaje60,
            [Description("70%")]
            porcentaje70,
            [Description("80%")]
            porcentaje80,
            [Description("90%")]
            porcentaje90,
            [Description("100%")]
            porcentaje100
        }

        public enum SolutionType
        {
            [Description("Consultoría")]
            Consultoria,
            [Description("On Grid")]
            OnGrid,
            Retail,
            Aislado,
            ER,
            [Description("Efic. Energética")]
            EficEnergetica,
            Servicio
        }

        public enum StatusOpportunity
        {
            Abierto,
            Ganado,
            Perdido
        }

        public enum StageOpportunity
        {
            Oportunidad,
            [Description("Cotización")]
            Cotizacion,
            [Description("Negociación")]
            Negociacion,
            Cerrado
        }

        public enum Currency
        {
            [Description("S/")]
            Soles,
            [Description("$")]
            Dolares
        }

        public enum StatusQuote
        {
            Pendiente,
            [Description("En Proceso")]
            EnProceso,
            [Description("Pendiente Aprob. Comercial")]
            AprobComercial,
            [Description("Pendiente Aprob. Técnica")]
            AprobTecnica,
            [Description("Desestimado")]
            Desestimado
        }

        public enum StatusTask
        {
            [Description("No Iniciado")]
            NoIniciado,
            [Description("En Proceso")]
            EnProceso,
            Completada,
            [Description("Pendiente de Información")]
            PendientedeInformacion,
            Aplazada
        }

        public enum PriorityTask
        {
            Alto,
            Medio,
            Bajo
        }

        public enum TypeTask
        {
            Llamada,
            Correo,
            Chat,
            [Description("Reunión")]
            Reunion,
            Demo
        }

        public enum UnitProduct
        {
            Unidades
        }

        public static IEnumerable<EnumDescriptionAndValue> GetAllEnumsWithChilds()
        {
            var enums = new List<EnumDescriptionAndValue>();
            var order = 0;

            foreach (var type in typeof(Enums).GetNestedTypes())
            {
                var parent = new EnumDescriptionAndValue
                {
                    Name = type.Name,
                    Order = order
                };

                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    var i = 0;
                    var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    parent.Childs.Add(new EnumDescriptionAndValue
                    {
                        Name = field.Name,
                        Value = field.GetRawConstantValue().ToString(),
                        Description = attribute == null ? field.Name : attribute.Description,
                        Order = i
                    });

                    i++;
                }

                enums.Add(parent);
                order++;
            }

            return enums;
        }
    }

    public class EnumDescriptionAndValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public List<EnumDescriptionAndValue> Childs { get; set; }

        public EnumDescriptionAndValue()
        {
            Childs = new List<EnumDescriptionAndValue>();
        }
    }
}
