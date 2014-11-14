﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("EnglishSchoolManagerModel", "FK__tblUsuari__AulaI__32E0915F", "Aula", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(EnglishSchoolManagerModel.Aula), "Usuario", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(EnglishSchoolManagerModel.Usuario), true)]

#endregion

namespace EnglishSchoolManagerModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ESMEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ESMEntities object using the connection string found in the 'ESMEntities' section of the application configuration file.
        /// </summary>
        public ESMEntities() : base("name=ESMEntities", "ESMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ESMEntities object.
        /// </summary>
        public ESMEntities(string connectionString) : base(connectionString, "ESMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ESMEntities object.
        /// </summary>
        public ESMEntities(EntityConnection connection) : base(connection, "ESMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Usuario> Usuarios
        {
            get
            {
                if ((_Usuarios == null))
                {
                    _Usuarios = base.CreateObjectSet<Usuario>("Usuarios");
                }
                return _Usuarios;
            }
        }
        private ObjectSet<Usuario> _Usuarios;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Aula> Aulas
        {
            get
            {
                if ((_Aulas == null))
                {
                    _Aulas = base.CreateObjectSet<Aula>("Aulas");
                }
                return _Aulas;
            }
        }
        private ObjectSet<Aula> _Aulas;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Usuarios EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsuarios(Usuario usuario)
        {
            base.AddObject("Usuarios", usuario);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Aulas EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAulas(Aula aula)
        {
            base.AddObject("Aulas", aula);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EnglishSchoolManagerModel", Name="Aula")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Aula : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Aula object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="particular">Initial value of the Particular property.</param>
        /// <param name="usuarioInsercaoId">Initial value of the UsuarioInsercaoId property.</param>
        /// <param name="usuarioAlteracaoId">Initial value of the UsuarioAlteracaoId property.</param>
        /// <param name="dataInsercao">Initial value of the DataInsercao property.</param>
        /// <param name="dataAlteracao">Initial value of the DataAlteracao property.</param>
        /// <param name="valorMensalidade">Initial value of the ValorMensalidade property.</param>
        public static Aula CreateAula(global::System.Int32 id, global::System.Boolean particular, global::System.Int32 usuarioInsercaoId, global::System.Int32 usuarioAlteracaoId, global::System.DateTime dataInsercao, global::System.DateTime dataAlteracao, global::System.Decimal valorMensalidade)
        {
            Aula aula = new Aula();
            aula.Id = id;
            aula.Particular = particular;
            aula.UsuarioInsercaoId = usuarioInsercaoId;
            aula.UsuarioAlteracaoId = usuarioAlteracaoId;
            aula.DataInsercao = dataInsercao;
            aula.DataAlteracao = dataAlteracao;
            aula.ValorMensalidade = valorMensalidade;
            return aula;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Descricao
        {
            get
            {
                return _Descricao;
            }
            set
            {
                OnDescricaoChanging(value);
                ReportPropertyChanging("Descricao");
                _Descricao = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Descricao");
                OnDescricaoChanged();
            }
        }
        private global::System.String _Descricao;
        partial void OnDescricaoChanging(global::System.String value);
        partial void OnDescricaoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HorariosJson
        {
            get
            {
                return _HorariosJson;
            }
            set
            {
                OnHorariosJsonChanging(value);
                ReportPropertyChanging("HorariosJson");
                _HorariosJson = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HorariosJson");
                OnHorariosJsonChanged();
            }
        }
        private global::System.String _HorariosJson;
        partial void OnHorariosJsonChanging(global::System.String value);
        partial void OnHorariosJsonChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Particular
        {
            get
            {
                return _Particular;
            }
            set
            {
                OnParticularChanging(value);
                ReportPropertyChanging("Particular");
                _Particular = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Particular");
                OnParticularChanged();
            }
        }
        private global::System.Boolean _Particular;
        partial void OnParticularChanging(global::System.Boolean value);
        partial void OnParticularChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UsuarioInsercaoId
        {
            get
            {
                return _UsuarioInsercaoId;
            }
            set
            {
                OnUsuarioInsercaoIdChanging(value);
                ReportPropertyChanging("UsuarioInsercaoId");
                _UsuarioInsercaoId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UsuarioInsercaoId");
                OnUsuarioInsercaoIdChanged();
            }
        }
        private global::System.Int32 _UsuarioInsercaoId;
        partial void OnUsuarioInsercaoIdChanging(global::System.Int32 value);
        partial void OnUsuarioInsercaoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UsuarioAlteracaoId
        {
            get
            {
                return _UsuarioAlteracaoId;
            }
            set
            {
                OnUsuarioAlteracaoIdChanging(value);
                ReportPropertyChanging("UsuarioAlteracaoId");
                _UsuarioAlteracaoId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UsuarioAlteracaoId");
                OnUsuarioAlteracaoIdChanged();
            }
        }
        private global::System.Int32 _UsuarioAlteracaoId;
        partial void OnUsuarioAlteracaoIdChanging(global::System.Int32 value);
        partial void OnUsuarioAlteracaoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DataInsercao
        {
            get
            {
                return _DataInsercao;
            }
            set
            {
                OnDataInsercaoChanging(value);
                ReportPropertyChanging("DataInsercao");
                _DataInsercao = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DataInsercao");
                OnDataInsercaoChanged();
            }
        }
        private global::System.DateTime _DataInsercao;
        partial void OnDataInsercaoChanging(global::System.DateTime value);
        partial void OnDataInsercaoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DataAlteracao
        {
            get
            {
                return _DataAlteracao;
            }
            set
            {
                OnDataAlteracaoChanging(value);
                ReportPropertyChanging("DataAlteracao");
                _DataAlteracao = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DataAlteracao");
                OnDataAlteracaoChanged();
            }
        }
        private global::System.DateTime _DataAlteracao;
        partial void OnDataAlteracaoChanging(global::System.DateTime value);
        partial void OnDataAlteracaoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ValorMensalidade
        {
            get
            {
                return _ValorMensalidade;
            }
            set
            {
                OnValorMensalidadeChanging(value);
                ReportPropertyChanging("ValorMensalidade");
                _ValorMensalidade = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ValorMensalidade");
                OnValorMensalidadeChanged();
            }
        }
        private global::System.Decimal _ValorMensalidade;
        partial void OnValorMensalidadeChanging(global::System.Decimal value);
        partial void OnValorMensalidadeChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EnglishSchoolManagerModel", "FK__tblUsuari__AulaI__32E0915F", "Usuario")]
        public EntityCollection<Usuario> Alunos
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Usuario>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Usuario");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Usuario>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Usuario", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="EnglishSchoolManagerModel", Name="Usuario")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Usuario : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Usuario object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="nome">Initial value of the Nome property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        /// <param name="senha">Initial value of the Senha property.</param>
        /// <param name="nivelAcesso">Initial value of the NivelAcesso property.</param>
        /// <param name="usuarioInsercaoId">Initial value of the UsuarioInsercaoId property.</param>
        /// <param name="usuarioAlteracaoId">Initial value of the UsuarioAlteracaoId property.</param>
        /// <param name="dataInsercao">Initial value of the DataInsercao property.</param>
        /// <param name="dataAlteracao">Initial value of the DataAlteracao property.</param>
        /// <param name="ativo">Initial value of the Ativo property.</param>
        public static Usuario CreateUsuario(global::System.Int32 id, global::System.String nome, global::System.String email, global::System.String senha, global::System.Int32 nivelAcesso, global::System.Int32 usuarioInsercaoId, global::System.Int32 usuarioAlteracaoId, global::System.DateTime dataInsercao, global::System.DateTime dataAlteracao, global::System.Boolean ativo)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;
            usuario.NivelAcesso = nivelAcesso;
            usuario.UsuarioInsercaoId = usuarioInsercaoId;
            usuario.UsuarioAlteracaoId = usuarioAlteracaoId;
            usuario.DataInsercao = dataInsercao;
            usuario.DataAlteracao = dataAlteracao;
            usuario.Ativo = ativo;
            return usuario;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                OnNomeChanging(value);
                ReportPropertyChanging("Nome");
                _Nome = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nome");
                OnNomeChanged();
            }
        }
        private global::System.String _Nome;
        partial void OnNomeChanging(global::System.String value);
        partial void OnNomeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Senha
        {
            get
            {
                return _Senha;
            }
            set
            {
                OnSenhaChanging(value);
                ReportPropertyChanging("Senha");
                _Senha = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Senha");
                OnSenhaChanged();
            }
        }
        private global::System.String _Senha;
        partial void OnSenhaChanging(global::System.String value);
        partial void OnSenhaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 NivelAcesso
        {
            get
            {
                return _NivelAcesso;
            }
            set
            {
                OnNivelAcessoChanging(value);
                ReportPropertyChanging("NivelAcesso");
                _NivelAcesso = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NivelAcesso");
                OnNivelAcessoChanged();
            }
        }
        private global::System.Int32 _NivelAcesso;
        partial void OnNivelAcessoChanging(global::System.Int32 value);
        partial void OnNivelAcessoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UsuarioInsercaoId
        {
            get
            {
                return _UsuarioInsercaoId;
            }
            set
            {
                OnUsuarioInsercaoIdChanging(value);
                ReportPropertyChanging("UsuarioInsercaoId");
                _UsuarioInsercaoId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UsuarioInsercaoId");
                OnUsuarioInsercaoIdChanged();
            }
        }
        private global::System.Int32 _UsuarioInsercaoId;
        partial void OnUsuarioInsercaoIdChanging(global::System.Int32 value);
        partial void OnUsuarioInsercaoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UsuarioAlteracaoId
        {
            get
            {
                return _UsuarioAlteracaoId;
            }
            set
            {
                OnUsuarioAlteracaoIdChanging(value);
                ReportPropertyChanging("UsuarioAlteracaoId");
                _UsuarioAlteracaoId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UsuarioAlteracaoId");
                OnUsuarioAlteracaoIdChanged();
            }
        }
        private global::System.Int32 _UsuarioAlteracaoId;
        partial void OnUsuarioAlteracaoIdChanging(global::System.Int32 value);
        partial void OnUsuarioAlteracaoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DataInsercao
        {
            get
            {
                return _DataInsercao;
            }
            set
            {
                OnDataInsercaoChanging(value);
                ReportPropertyChanging("DataInsercao");
                _DataInsercao = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DataInsercao");
                OnDataInsercaoChanged();
            }
        }
        private global::System.DateTime _DataInsercao;
        partial void OnDataInsercaoChanging(global::System.DateTime value);
        partial void OnDataInsercaoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DataAlteracao
        {
            get
            {
                return _DataAlteracao;
            }
            set
            {
                OnDataAlteracaoChanging(value);
                ReportPropertyChanging("DataAlteracao");
                _DataAlteracao = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DataAlteracao");
                OnDataAlteracaoChanged();
            }
        }
        private global::System.DateTime _DataAlteracao;
        partial void OnDataAlteracaoChanging(global::System.DateTime value);
        partial void OnDataAlteracaoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telefone
        {
            get
            {
                return _Telefone;
            }
            set
            {
                OnTelefoneChanging(value);
                ReportPropertyChanging("Telefone");
                _Telefone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Telefone");
                OnTelefoneChanged();
            }
        }
        private global::System.String _Telefone;
        partial void OnTelefoneChanging(global::System.String value);
        partial void OnTelefoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Ativo
        {
            get
            {
                return _Ativo;
            }
            set
            {
                OnAtivoChanging(value);
                ReportPropertyChanging("Ativo");
                _Ativo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Ativo");
                OnAtivoChanged();
            }
        }
        private global::System.Boolean _Ativo;
        partial void OnAtivoChanging(global::System.Boolean value);
        partial void OnAtivoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> AulaId
        {
            get
            {
                return _AulaId;
            }
            set
            {
                OnAulaIdChanging(value);
                ReportPropertyChanging("AulaId");
                _AulaId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AulaId");
                OnAulaIdChanged();
            }
        }
        private Nullable<global::System.Int32> _AulaId;
        partial void OnAulaIdChanging(Nullable<global::System.Int32> value);
        partial void OnAulaIdChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("EnglishSchoolManagerModel", "FK__tblUsuari__AulaI__32E0915F", "Aula")]
        public Aula Aula
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Aula>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Aula").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Aula>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Aula").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Aula> AulaReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Aula>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Aula");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Aula>("EnglishSchoolManagerModel.FK__tblUsuari__AulaI__32E0915F", "Aula", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}