using DI.UnderWriting.IllusData.Interfaces;
using DI.UnderWriting.Interfaces;
using DI.UnderWriting.Properties;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DI.UnderWriting
{
    public class UnderWritingDIManager
    {
        #region PrivateMembers
        private readonly IUnityContainer unityContainer;
        #endregion

        public UnderWritingDIManager()
        {
            unityContainer = new UnityContainer();

            if (Settings.Default.GoByWebService)
                unityContainer.LoadConfiguration("DIUnderWritingWS");
            else
                unityContainer.LoadConfiguration("DIUnderWritingBll");
        }

        public ICase CaseManager
        {
            get
            {
                return
                    unityContainer.Resolve<ICase>();
            }
        }
        public IContact ContactManager
        {
            get
            {
                return
                    unityContainer.Resolve<IContact>();
            }
        }
        public IForm FormManager
        {
            get
            {
                return
                    unityContainer.Resolve<IForm>();
            }
        }
        public IDropDown DropDownManager
        {
            get
            {
                return
                    unityContainer.Resolve<IDropDown>();
            }
        }
        public IAmmendment AmmendmentManager
        {
            get
            {
                return
                    unityContainer.Resolve<IAmmendment>();
            }
        }
        public IBeneficiary BeneficiaryManager
        {
            get
            {
                return
                    unityContainer.Resolve<IBeneficiary>();
            }
        }
        public IRider RiderManager
        {
            get
            {
                return
                    unityContainer.Resolve<IRider>();
            }
        }
        public IPayment PaymentManager
        {
            get
            {
                return
                    unityContainer.Resolve<IPayment>();
            }
        }
        public IRequirement RequirementManager
        {
            get
            {
                return
                    unityContainer.Resolve<IRequirement>();
            }
        }
        public IPolicy PolicyManager
        {
            get
            {
                return
                    unityContainer.Resolve<IPolicy>();
            }
        }
        public IMedical MedicalManager
        {
            get
            {
                return
                    unityContainer.Resolve<IMedical>();
            }
        }
        public INote NoteManager
        {
            get
            {
                return
                    unityContainer.Resolve<INote>();
            }
        }
        public IStep StepManager
        {
            get
            {
                return
                    unityContainer.Resolve<IStep>();
            }
        }
        public IConfirmationCall ConfirmationCallManager
        {
            get
            {
                return
                    unityContainer.Resolve<IConfirmationCall>();
            }
        }
        public IDataReview DataReviewManager
        {
            get
            {
                return
                    unityContainer.Resolve<IDataReview>();
            }
        }
        public ICallRex CallRexManager
        {
            get
            {
                return
                    unityContainer.Resolve<ICallRex>();
            }
        }
        public IHealthDeclaration HealthDeclarationManager
        {
            get
            {
                return
                    unityContainer.Resolve<IHealthDeclaration>();
            }
        }
        public IHealth HealthManager
        {
            get
            {
                return
                    unityContainer.Resolve<IHealth>();
            }
        }
        public IVehicle VehicleManager
        {
            get
            {
                return
                    unityContainer.Resolve<IVehicle>();
            }
        }
        public IProperty PropertyManager
        {
            get
            {
                return
                    unityContainer.Resolve<IProperty>();
            }
        }

        public INavy NavyManager
        {
            get
            {
                return
                    unityContainer.Resolve<INavy>();
            }
        }

        public IBail BailManager
        {
            get
            {
                return
                    unityContainer.Resolve<IBail>();
            }
        }

        public IAirPlane AirPlaneManager
        {
            get
            {
                return
                    unityContainer.Resolve<IAirPlane>();
            }
        }

        public ITransport TransportManager
        {
            get
            {
                return
                    unityContainer.Resolve<ITransport>();
            }
        }
       
        public IIllusData IIllusDataManager
        {
            get
            {
                return
                    unityContainer.Resolve<IIllusData>();
            }
        }

        public IAlliedLinesReview AlliedLinesReviewManager
        {
            get
            {
                return
                    unityContainer.Resolve<IAlliedLinesReview>();
            }
        }


        #region GarbageZone
        /*
        using System;
        using DI.UnderWriting.IllusData.Implementations;
        using DI.UnderWriting.IllusData.Interfaces;
        using DI.UnderWriting.Implementations;
        using DI.UnderWriting.Interfaces;
        using DI.UnderWriting.Properties;
        using Microsoft.Practices.Unity;
        using Microsoft.Practices.Unity.Configuration;
         
         private ICase _caseManager;
        private IContact _contactManager;
        private IDropDown _dropDownManager;
        private IAmmendment _ammendmentManager;
        private IBeneficiary _beneficiaryManager;
        private IRider _riderManager;
        private IPayment _paymentManager;
        private IRequirement _requirementManager;
        private IPolicy _policyManager;
        private IMedical _medicalManager;
        private INote _noteManager;
        private IStep _stepManager;
        private IConfirmationCall _confirmationCallManager;
        private IDataReview _dataReviewManager;
        private ICallRex _callRexManager;
        private IHealthDeclaration _healthDeclarationManager;

        private IIllusData _iIllusDataManager;
         
        private T GetInstance<T>()
        {
            T result;
            Type type;

            type = typeof(T);

            switch (type.FullName)
            {
                #region UnderWriting
                case "DI.UnderWriting.Interfaces.ICase":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new CaseWS()));
                    else
                        result = (T)((object)(new CaseBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IContact":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new ContacttWS()));
                    else
                        result = (T)((object)(new ContactBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IDropDown":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new DropDownWS()));
                    else
                        result = (T)((object)(new DropDownBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IBeneficiary":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new BeneficiaryWS()));
                    else
                        result = (T)((object)(new BeneficiaryBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IAmmendment":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new AmmendmentWS()));
                    else
                        result = (T)((object)(new AmmendmentBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IRider":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new RiderWS()));
                    else
                        result = (T)((object)(new RiderBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IPayment":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new PaymentWS()));
                    else
                        result = (T)((object)(new PaymentBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IRequirement":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new RequirementWS()));
                    else
                        result = (T)((object)(new RequirementBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IPolicy":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new PolicyWS()));
                    else
                        result = (T)((object)(new PolicyBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IMedical":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new MedicalWS()));
                    else
                        result = (T)((object)(new MedicalBll()));
                    break;
                case "DI.UnderWriting.Interfaces.INote":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new NoteWS()));
                    else
                        result = (T)((object)(new NoteBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IStep":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new StepWS()));
                    else
                        result = (T)((object)(new StepBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IConfirmationCall":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new ConfirmationCallWS()));
                    else
                        result = (T)((object)(new ConfirmationCallBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IDataReview":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new DataReviewWS()));
                    else
                        result = (T)((object)(new DataReviewBll()));
                    break;
                case "DI.UnderWriting.Interfaces.ICallRex":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new CallRexWS()));
                    else
                        result = (T)((object)(new CallRexBll()));
                    break;
                case "DI.UnderWriting.Interfaces.IHealthDeclaration":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new HealthDeclarationWS()));
                    else
                        result = (T)((object)(new HealthDeclarationBll()));
                    break;
                #endregion

                #region IllusData
                case "DI.UnderWriting.IllusData.Interfaces.IIllusData":
                    if (Settings.Default.GoByWebService)
                        result = (T)((object)(new IllusDataWS()));
                    else
                        result = (T)((object)(new IllusDataBll()));
                    break;
                #endregion

                default:
                    result = default(T);
                    break;
            }

            return
                result;
        }
        */
        #endregion
    }
}
