using System;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.Repositories.IllusData;

namespace DATA.UnderWriting.UnitOfWork
{
    public sealed class SingletonUnitOfWork : IDisposable
    {
        #region Private Variables
        private readonly string conexionStringForAdo;
        private readonly GlobalEntityDataModel globalModel;
        private readonly GlobalEntities globalModelExtended;
        private readonly IllusDataEntityDataModel illusDataModel;
        private static readonly SingletonUnitOfWork singletonInstance;
        private bool disposed;
        private AmmendmentRepository _ammendmentRepository;
        private BeneficiaryRepository _beneficiaryRepository;
        private CaseRepository _caseRepository;
        private ConfirmationCallRepository _confirmationCallRepository;
        private ContactRepository _contactRepository;
        private FormRepository _formRepository;
        private DataReviewRepository _dataReviewRepository;
        private DropDownRepository _dropDownRepository;
        private HealthDeclarationRepository _healthDeclarationRepository;
        private MedicalRepository _medicalRepository;
        private NoteRepository _noteRepository;
        private PaymentRepository _paymentRepository;
        private PolicyRepository _policyRepository;
        private RequirementRepository _requirementRepository;
        private RiderRepository _riderRepository;
        private StepRepository _stepRepository;
        private IllustratorRepository _illustratorRepository;
        private HealthRepository _healthRepository;
        private VehicleRepository _vehicleRepository;
        private PropertyRepository _propertyRepository;
        private NavyRepository _navyRepository;
        private TransportRepository _transportRepository;
        private AirPlaneRepository _airPlaneRepository;
        private BailRepository _bailRepository;
        private AlliedLinesReviewRepository _alliedLinesReviewRepository;
        #endregion


        #region Public Properties
        public static SingletonUnitOfWork Instance
        {
            get
            {
                return
                    singletonInstance;
            }
        }

        public AmmendmentRepository AmmendmentRepository
        {
            get
            {
                if (this._ammendmentRepository == null)
                {
                    this._ammendmentRepository = new AmmendmentRepository(globalModel, globalModelExtended);
                }
                return
                    _ammendmentRepository;
            }
        }
        public BeneficiaryRepository BeneficiaryRepository
        {
            get
            {
                if (this._beneficiaryRepository == null)
                {
                    this._beneficiaryRepository = new BeneficiaryRepository(globalModel, globalModelExtended);
                }
                return
                    _beneficiaryRepository;
            }
        }
        public CaseRepository CaseRepository
        {
            get
            {
                if (this._caseRepository == null)
                {
                    this._caseRepository = new CaseRepository(globalModel, globalModelExtended);
                }
                return
                    _caseRepository;
            }
        }

        public ConfirmationCallRepository ConfirmationCallRepository
        {
            get
            {
                if (this._confirmationCallRepository == null)
                {
                    this._confirmationCallRepository = new ConfirmationCallRepository(globalModel, globalModelExtended);
                }
                return
                    _confirmationCallRepository;
            }
        }

        public ContactRepository ContactRepository
        {
            get
            {
                if (this._contactRepository == null)
                {
                    this._contactRepository = new ContactRepository(globalModel,globalModelExtended);
                }
                return
                    _contactRepository;
            }
        }

        public DataReviewRepository DataReviewRepository
        {
            get
            {
                if (this._dataReviewRepository == null)
                {
                    this._dataReviewRepository = new DataReviewRepository(globalModel, globalModelExtended, conexionStringForAdo);
                }
                return
                    _dataReviewRepository;
            }
        }

        public FormRepository FormRepository
        {
            get
            {
                if (this._formRepository == null)
                {
                    this._formRepository = new FormRepository(globalModel, globalModelExtended, conexionStringForAdo);
                }
                return
                    _formRepository;
            }
        }

        public DropDownRepository DropDownRepository
        {
            get
            {
                if (this._dropDownRepository == null)
                {
                    this._dropDownRepository = new DropDownRepository(globalModel, globalModelExtended);
                }
                return
                    _dropDownRepository;
            }
        }

        public HealthDeclarationRepository HealthDeclarationRepository
        {
            get
            {
                if (this._healthDeclarationRepository == null)
                {
                    this._healthDeclarationRepository = new HealthDeclarationRepository(globalModel, globalModelExtended, conexionStringForAdo);
                }
                return
                    _healthDeclarationRepository;
            }
        }

        public MedicalRepository MedicalRepository
        {
            get
            {
                if (this._medicalRepository == null)
                {
                    this._medicalRepository = new MedicalRepository(globalModel, globalModelExtended);
                }
                return
                    _medicalRepository;
            }
        }
        public NoteRepository NoteRepository
        {
            get
            {
                if (this._noteRepository == null)
                {
                    this._noteRepository = new NoteRepository(globalModel, globalModelExtended);
                }
                return
                    _noteRepository;
            }
        }
        public PaymentRepository PaymentRepository
        {
            get
            {
                if (this._paymentRepository == null)
                {
                    this._paymentRepository = new PaymentRepository(globalModel, globalModelExtended);
                }
                return
                    _paymentRepository;
            }
        }

        public PolicyRepository PolicyRepository
        {
            get
            {
                if (this._policyRepository == null)
                {
                    this._policyRepository = new PolicyRepository(globalModel, globalModelExtended, conexionStringForAdo);
                }
                return
                    _policyRepository;
            }
        }
        public RequirementRepository RequirementRepository
        {
            get
            {
                if (this._requirementRepository == null)
                {
                    this._requirementRepository = new RequirementRepository(globalModel, globalModelExtended);
                }
                return
                    _requirementRepository;
            }
        }
        public RiderRepository RiderRepository
        {
            get
            {
                if (this._riderRepository == null)
                {
                    this._riderRepository = new RiderRepository(globalModel, globalModelExtended);
                }
                return
                    _riderRepository;
            }
        }
        public StepRepository StepRepository
        {
            get
            {
                if (this._stepRepository == null)
                {
                    this._stepRepository = new StepRepository(globalModel, globalModelExtended);
                }
                return
                    _stepRepository;
            }
        }
        public IllustratorRepository IllustratorRepository
        {
            get
            {
                if (this._illustratorRepository == null)
                {
                    this._illustratorRepository = new IllustratorRepository(illusDataModel);
                }
                return
                    _illustratorRepository;
            }
        }
        public HealthRepository HealthRepository
        {
            get
            {
                if (this._healthRepository == null)
                {
                    this._healthRepository = new HealthRepository(globalModel, globalModelExtended);
                }
                return
                    _healthRepository;
            }
        }
        public VehicleRepository VehicleRepository
        {
            get
            {
                if (this._vehicleRepository == null)
                {
                    this._vehicleRepository = new VehicleRepository(globalModel, globalModelExtended);
                }

                return
                    _vehicleRepository;
            }
        }
        public PropertyRepository PropertyRepository
        {
            get
            {
                if (this._propertyRepository == null)
                {
                    this._propertyRepository = new PropertyRepository(globalModel, globalModelExtended);
                }

                return
                    _propertyRepository;
            }
        }
        public NavyRepository NavyRepository
        {
            get
            {
                if (this._navyRepository == null)
                {
                    this._navyRepository = new NavyRepository(globalModel, globalModelExtended);
                }

                return
                    _navyRepository;
            }
        }
        public TransportRepository TransportRepository
        {
            get
            {
                if (this._transportRepository == null)
                {
                    this._transportRepository = new TransportRepository(globalModel, globalModelExtended);
                }

                return
                    _transportRepository;
            }
        }
        public AirPlaneRepository AirPlaneRepository
        {
            get
            {
                if (this._airPlaneRepository == null)
                {
                    this._airPlaneRepository = new AirPlaneRepository(globalModel, globalModelExtended);
                }

                return
                    _airPlaneRepository;
            }
        }
        public BailRepository BailRepository
        {
            get
            {
                if (this._bailRepository == null)
                {
                    this._bailRepository = new BailRepository(globalModel, globalModelExtended);
                }

                return
                    _bailRepository;
            }
        }
        public AlliedLinesReviewRepository AlliedLinesReviewRepository
        {
            get
            {
                if (this._alliedLinesReviewRepository == null)
                {
                    this._alliedLinesReviewRepository = new AlliedLinesReviewRepository(globalModel, globalModelExtended);
                }

                return
                    _alliedLinesReviewRepository;
            }
        }
        #endregion

        #region Private Methods
        static SingletonUnitOfWork()
        {
            singletonInstance = new SingletonUnitOfWork();
        }

        private SingletonUnitOfWork()
        {
            globalModel = new GlobalEntityDataModel();
            globalModelExtended = new GlobalEntities();
            illusDataModel = new IllusDataEntityDataModel();
            conexionStringForAdo = System.Configuration.ConfigurationManager.ConnectionStrings["GlobalForAdoNet"].ToString();
            disposed = false;
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    globalModel.Dispose();
                }
            }

            this.disposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

