using ISAutobuskaStanica.DataModel;
using ISAutobuskaStanica.DataModel.DAO;
using ISAutobuskaStanica.DataModel.Services;
using ISAutobuskaStanica.WPF.Helpers;
using ISAutobuskaStanica.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISAutobuskaStanica.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        //commands
        public MyICommand AddAStanica { get; set; }
        public MyICommand AddPrevoznik { get; set; }
        public MyICommand AddSezona { get; set; }
        public MyICommand AddUgovor { get; set; }
        public MyICommand AddVozac { get; set; }
        public MyICommand AddLinija { get; set; }
        public MyICommand AddRedVoznje { get; set; }
        public MyICommand AddPregledLinija { get; set; }
        public MyICommand AddAutobus { get; set; }
        public MyICommand DeleteStanica { get; set; }
        public MyICommand DeleteSezona { get; set; }
        public MyICommand DeletePrevoznik { get; set; }
        public MyICommand DeleteUgovor { get; set; }
        public MyICommand DeleteRedVoznje { get; set; }
        public MyICommand DeleteVozac { get; set; }
        public MyICommand DeleteLinija { get; set; }
        public MyICommand DeleteAutobus { get; set; }

        public MyICommand EditStanica { get; set; }
        public MyICommand EditSezona { get; set; }
        public MyICommand EditPrevoznik { get; set; }
        public MyICommand EditVozac { get; set; }
        

        //props
        public Window Window { get; set; }

        //bindable lists
        private List<AutobuskaStanica> autobuskaStanica = new List<AutobuskaStanica>();
        public List<AutobuskaStanica> AutobuskaStanica
        {
            get {
                return autobuskaStanica;
            }
            set {
                autobuskaStanica = value;
                OnPropertyChanged("AutobuskaStanica");
            }
        }
        public AutobuskaStanica SelectedAutobuskaStanica { get; set; }

        private List<VoznaSezona> voznaSezona = new List<VoznaSezona>();
        public List<VoznaSezona> VoznaSezona
        {
            get
            {
                return voznaSezona;
            }
            set
            {
                voznaSezona = value;
                OnPropertyChanged("VoznaSezona");
            }
        }
        public VoznaSezona SelectedVoznaSezona { get; set; }

        private List<AutobuskiPrevoznik> autobuskiPrevoznik = new List<AutobuskiPrevoznik>();
        public List<AutobuskiPrevoznik> AutobuskiPrevoznik
        {
            get
            {
                return autobuskiPrevoznik;
            }
            set
            {
                autobuskiPrevoznik = value;
                OnPropertyChanged("AutobuskiPrevoznik");
            }
        }
        public AutobuskiPrevoznik SelectedAutobuskiPrevoznik { get; set; }

        private List<Ugovor> ugovor = new List<Ugovor>();
        public List<Ugovor> Ugovori
        {
            get
            {
                return ugovor;
            }
            set
            {
                ugovor = value;
                OnPropertyChanged("Ugovori");
            }
        }
        public Ugovor SelectedUgovor { get; set; }

        private List<RedVoznje> redVoznje = new List<RedVoznje>();
        public List<RedVoznje> RedVoznje
        {
            get
            {
                return redVoznje;
            }
            set
            {
                redVoznje = value;
                OnPropertyChanged("RedVoznje");
            }
        }
        public RedVoznje SelectedRedVoznje { get; set; }

        private List<Vozac> vozaci = new List<Vozac>();
        public List<Vozac> Vozaci
        {
            get
            {
                return vozaci;
            }
            set
            {
                vozaci = value;
                OnPropertyChanged("Vozaci");
            }
        }
        public Vozac SelectedVozac { get; set; }

        private List<Linija> linija = new List<Linija>();
        public List<Linija> Linija
        {
            get
            {
                return linija;
            }
            set
            {
                linija = value;
                OnPropertyChanged("Linija");
            }
        }
        public Linija SelectedLinija { get; set; }

        private List<Autobus> autobusi = new List<Autobus>();
        public List<Autobus> Autobusi
        {
            get
            {
                return autobusi;
            }
            set
            {
                autobusi = value;
                OnPropertyChanged("Autobusi");
            }
        }
        public Autobus SelectedAutobus { get; set; }

        private List<Zglobni> zglobni = new List<Zglobni>();
        public List<Zglobni> Zglobni
        {
            get
            {
                return zglobni;
            }
            set
            {
                zglobni = value;
                OnPropertyChanged("Zglobni");
            }
        }
        public Zglobni SelectedZglobni  { get; set; }

        private List<Elektricni> elektricni = new List<Elektricni>();
        public List<Elektricni> Elektricni
        {
            get
            {
                return elektricni;
            }
            set
            {
                elektricni = value;
                OnPropertyChanged("Elektricni");
            }
        }
        public Elektricni SelectedElektricni { get; set; }


        //Services
        private AutobuskaStanicaService ass = new AutobuskaStanicaService();
        private VoznaSezonaService vss = new VoznaSezonaService();
        private AutobuskiPrevoznikService aps = new AutobuskiPrevoznikService();
        private UgovorService ugovorService = new UgovorService();
        private RedVoznjeService rvService = new RedVoznjeService();
        private VozacService vozacService = new VozacService();
        private LinijaService linijaService = new LinijaService();
        private AutobusServices autobusService = new AutobusServices();
        private ZglobniDAO zdao = new ZglobniDAO();
        private ElektricniDAO edao = new ElektricniDAO();
        //constructor
        public MainViewModel() 
        {
            AddAStanica = new MyICommand(OnAddStanica);
            AddSezona = new MyICommand(OnAddSezona);
            AddPrevoznik = new MyICommand(OnAddPrevoznik);
            AddUgovor = new MyICommand(OnAddUgovor);
            AddRedVoznje = new MyICommand(OnAddRed);
            AddVozac = new MyICommand(OnAddVozac);
            AddLinija = new MyICommand(OnAddLinija);
            AddAutobus = new MyICommand(OnAddAutobus);

            DeleteStanica = new MyICommand(OnDeleteStanica);
            DeleteSezona = new MyICommand(OnDeleteSezona);
            DeletePrevoznik = new MyICommand(OnDeletePrevoznik);
            DeleteUgovor = new MyICommand(OnDeleteUgovor);
            DeleteRedVoznje = new MyICommand(OnDeleteRedVoznje);
            DeleteVozac = new MyICommand(OnDeleteVozac);
            DeleteLinija = new MyICommand(OnDeleteLinija);
            DeleteAutobus = new MyICommand(OnDeleteAutobus);

            EditStanica = new MyICommand(OnEditStanica);
            EditSezona = new MyICommand(OnEditSezona);
            EditPrevoznik = new MyICommand(OnEditPrevoznik);
            EditVozac = new MyICommand(OnEditVozac);

            AutobuskaStanica = ass.GetAllAutobuskaStanica();
            VoznaSezona = vss.GetAllVoznaSezona();
            AutobuskiPrevoznik = aps.GetAllAutobuskiPrevoznik();
            Ugovori = ugovorService.GetAllUgovor();
            RedVoznje = rvService.GetAllRedVoznje();
            Vozaci = vozacService.GetAllVozac();
            Linija = linijaService.GetAllLinija();
            Autobusi = autobusService.GetAllAutobus();
            Zglobni = zdao.GetAll();
            Elektricni = edao.GetAll();
        }

        private void OnEditVozac()
        {
            AddVozacWindow win = new AddVozacWindow(SelectedVozac);
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                Vozaci = vozacService.GetAllVozac();
            }
        }

        private void OnEditPrevoznik()
        {
            AddAutobuskiPrevoznikWindow win = new AddAutobuskiPrevoznikWindow(SelectedAutobuskiPrevoznik);
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                AutobuskiPrevoznik = aps.GetAllAutobuskiPrevoznik();
            }
        }

        private void OnEditSezona()
        {
            AddSezonaWindow win = new AddSezonaWindow(SelectedVoznaSezona);
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                VoznaSezona = vss.GetAllVoznaSezona();
            }
        }

        private void OnEditStanica()
        {
            AddAStanicaWindow win = new AddAStanicaWindow(SelectedAutobuskaStanica);
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                AutobuskaStanica = ass.GetAllAutobuskaStanica();
            }
        }

        private void OnDeleteAutobus()
        {
            autobusService.DeleteAutobus(SelectedAutobus.AutobuskiPrevoznikIDAP, SelectedAutobus.IDA);
            Autobusi = autobusService.GetAllAutobus();
            Zglobni = zdao.GetAll();
            Elektricni = edao.GetAll();
        }

        private void OnDeleteLinija()
        {
            linijaService.DeleteLinija(SelectedLinija.AutobuskiPrevoznikIDAP, SelectedLinija.NazivLinije);
            Linija = linijaService.GetAllLinija();
        }

        private void OnDeleteVozac()
        {
            vozacService.DeleteVozac(SelectedVozac.AutobuskiPrevoznikIDAP, SelectedVozac.IDV);
            Vozaci = vozacService.GetAllVozac();
        }

        private void OnDeleteRedVoznje()
        {
            rvService.DeleteRedVoznje(SelectedRedVoznje.AutobuskaStanicaIDAS, SelectedRedVoznje.VoznaSezonaIdSezone);
            RedVoznje = rvService.GetAllRedVoznje();
        }

        private void OnDeleteUgovor()
        {
            ugovorService.DeleteUgovor(SelectedUgovor.AutobuskaStanicaIDAS, SelectedUgovor.AutobuskiPrevoznikIDAP);
            Ugovori = ugovorService.GetAllUgovor();
        }

        private void OnDeletePrevoznik()
        {
            aps.DeleteAutobuskiPrevoznik(SelectedAutobuskiPrevoznik.IDAP);

            AutobuskiPrevoznik = aps.GetAllAutobuskiPrevoznik();
            Ugovori = ugovorService.GetAllUgovor();
            Vozaci = vozacService.GetAllVozac();
            Linija = linijaService.GetAllLinija();
            Autobusi = autobusService.GetAllAutobus();
            Zglobni = zdao.GetAll();
            Elektricni = edao.GetAll();
        }

        private void OnDeleteSezona()
        {
            vss.DeleteVoznaSezona(SelectedVoznaSezona.IdSezone);
            VoznaSezona = vss.GetAllVoznaSezona();
            RedVoznje = rvService.GetAllRedVoznje();
        }

        private void OnDeleteStanica()
        {
            ass.DeleteAutobuskaStanica(SelectedAutobuskaStanica.IDAS);
            AutobuskaStanica = ass.GetAllAutobuskaStanica();
            Ugovori = ugovorService.GetAllUgovor();
            RedVoznje = rvService.GetAllRedVoznje();
        }

        private void OnAddAutobus()
        {
            AddAutobusWindow win = new AddAutobusWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                Autobusi = autobusService.GetAllAutobus();
                Zglobni = zdao.GetAll();
                Elektricni = edao.GetAll();
            }
        }

        private void OnAddLinija()
        {
            AddLinijaWindow win = new AddLinijaWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                Linija = linijaService.GetAllLinija();
            }
        }

        private void OnAddVozac()
        {
            AddVozacWindow win = new AddVozacWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue) 
            {
                Vozaci = vozacService.GetAllVozac();
            }
        }

        private void OnAddRed()
        {
            AddRedVoznjeWindow win = new AddRedVoznjeWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue) 
            {
                RedVoznje = rvService.GetAllRedVoznje();
            }
        }

        private void OnAddUgovor()
        {
            AddUgovorWindow win = new AddUgovorWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue) 
            {
                Ugovori = ugovorService.GetAllUgovor();
            }
        }

        private void OnAddPrevoznik()
        {
            AddAutobuskiPrevoznikWindow win = new AddAutobuskiPrevoznikWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                AutobuskiPrevoznik = aps.GetAllAutobuskiPrevoznik();
            }
        }

        private void OnAddSezona()
        {
            AddSezonaWindow win = new AddSezonaWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue)
            {
                VoznaSezona = vss.GetAllVoznaSezona();
            }
        }

        //methods for commands
        private void OnAddStanica()
        {
            AddAStanicaWindow win = new AddAStanicaWindow();
            win.ShowDialog();
            if (win.DialogResult.HasValue) 
            {
                AutobuskaStanica = ass.GetAllAutobuskaStanica();
            }
        }
    }
}
