var Enums = { EntityType: {Leads: {name: 'Leads',description: 'Leads',value: 0},Opportunities: {name: 'Opportunities',description: 'Opportunities',value: 1},Quotes: {name: 'Quotes',description: 'Quotes',value: 2},},IncomeType: {Total: {name: 'Total',description: 'Total',value: 0},CompanyTotal: {name: 'CompanyTotal',description: 'CompanyTotal',value: 1},TeacherTotal: {name: 'TeacherTotal',description: 'TeacherTotal',value: 2},},PanelMenu: {Resumen: {name: 'Resumen',description: 'Resumen',value: 0},Perfil: {name: 'Perfil',description: 'Perfil',value: 1},Cuenta: {name: 'Cuenta',description: 'Cuenta',value: 2},Lead: {name: 'Lead',description: 'Lead',value: 3},Oportunidades: {name: 'Oportunidades',description: 'Oportunidades',value: 4},Tareas: {name: 'Tareas',description: 'Tareas',value: 5},},Gender: {Male: {name: 'Male',description: 'Masculino',value: 0},Female: {name: 'Female',description: 'Femenino',value: 1},},Status: {Enable: {name: 'Enable',description: 'Enable',value: 0},Disable: {name: 'Disable',description: 'Disable',value: 1},},MyFilters: {IsDeleted: {name: 'IsDeleted',description: 'IsDeleted',value: 0},},Industry: {Mineria: {name: 'Mineria',description: 'Minería',value: 0},OilyGas: {name: 'OilyGas',description: 'Oil & Gas',value: 1},Retail: {name: 'Retail',description: 'Retail',value: 2},Telecom: {name: 'Telecom',description: 'Telecom',value: 3},Turismo: {name: 'Turismo',description: 'Turismo',value: 4},Industrial: {name: 'Industrial',description: 'Industrial',value: 5},Rural: {name: 'Rural',description: 'Rural',value: 6},Servicios: {name: 'Servicios',description: 'Servicios',value: 7},Interconectado: {name: 'Interconectado',description: 'Interconectado',value: 8},},Sector: {Publico: {name: 'Publico',description: 'Público',value: 0},Privado: {name: 'Privado',description: 'Privado',value: 1},},StatusUser: {Enable: {name: 'Enable',description: 'Enable',value: 0},Disable: {name: 'Disable',description: 'Disable',value: 1},},StatusLead: {Califica: {name: 'Califica',description: 'Califica',value: 0},NoCalifica: {name: 'NoCalifica',description: 'No Califica',value: 1},},RankingLead: {Alto: {name: 'Alto',description: 'Alto',value: 0},Medio: {name: 'Medio',description: 'Medio',value: 1},Bajo: {name: 'Bajo',description: 'Bajo',value: 2},},ProbabilityOpportunity: {porcentaje0: {name: 'porcentaje0',description: '0%',value: 0},porcentaje10: {name: 'porcentaje10',description: '10%',value: 1},porcentaje20: {name: 'porcentaje20',description: '20%',value: 2},porcentaje30: {name: 'porcentaje30',description: '30%',value: 3},porcentaje40: {name: 'porcentaje40',description: '40%',value: 4},porcentaje50: {name: 'porcentaje50',description: '50%',value: 5},porcentaje60: {name: 'porcentaje60',description: '60%',value: 6},porcentaje70: {name: 'porcentaje70',description: '70%',value: 7},porcentaje80: {name: 'porcentaje80',description: '80%',value: 8},porcentaje90: {name: 'porcentaje90',description: '90%',value: 9},porcentaje100: {name: 'porcentaje100',description: '100%',value: 10},},SolutionType: {Consultoria: {name: 'Consultoria',description: 'Consultoría',value: 0},OnGrid: {name: 'OnGrid',description: 'On Grid',value: 1},Retail: {name: 'Retail',description: 'Retail',value: 2},Aislado: {name: 'Aislado',description: 'Aislado',value: 3},ER: {name: 'ER',description: 'ER',value: 4},EficEnergetica: {name: 'EficEnergetica',description: 'Efic. Energética',value: 5},Servicio: {name: 'Servicio',description: 'Servicio',value: 6},},StatusOpportunity: {Abierto: {name: 'Abierto',description: 'Abierto',value: 0},Ganado: {name: 'Ganado',description: 'Ganado',value: 1},Perdido: {name: 'Perdido',description: 'Perdido',value: 2},},StageOpportunity: {Oportunidad: {name: 'Oportunidad',description: 'Oportunidad',value: 0},Cotizacion: {name: 'Cotizacion',description: 'Cotización',value: 1},Negociacion: {name: 'Negociacion',description: 'Negociación',value: 2},Cerrado: {name: 'Cerrado',description: 'Cerrado',value: 3},},Currency: {Soles: {name: 'Soles',description: 'S/',value: 0},Dolares: {name: 'Dolares',description: '$',value: 1},},StatusQuote: {Pendiente: {name: 'Pendiente',description: 'Pendiente',value: 0},EnProceso: {name: 'EnProceso',description: 'En Proceso',value: 1},AprobComercial: {name: 'AprobComercial',description: 'Pendiente Aprob. Comercial',value: 2},AprobTecnica: {name: 'AprobTecnica',description: 'Pendiente Aprob. Técnica',value: 3},Desestimado: {name: 'Desestimado',description: 'Desestimado',value: 4},},StatusTask: {NoIniciado: {name: 'NoIniciado',description: 'No Iniciado',value: 0},EnProceso: {name: 'EnProceso',description: 'En Proceso',value: 1},Completada: {name: 'Completada',description: 'Completada',value: 2},PendientedeInformacion: {name: 'PendientedeInformacion',description: 'Pendiente de Información',value: 3},Aplazada: {name: 'Aplazada',description: 'Aplazada',value: 4},},PriorityTask: {Alto: {name: 'Alto',description: 'Alto',value: 0},Medio: {name: 'Medio',description: 'Medio',value: 1},Bajo: {name: 'Bajo',description: 'Bajo',value: 2},},TypeTask: {Llamada: {name: 'Llamada',description: 'Llamada',value: 0},Correo: {name: 'Correo',description: 'Correo',value: 1},Chat: {name: 'Chat',description: 'Chat',value: 2},Reunion: {name: 'Reunion',description: 'Reunión',value: 3},Demo: {name: 'Demo',description: 'Demo',value: 4},},UnitProduct: {Unidades: {name: 'Unidades',description: 'Unidades',value: 0},}, };