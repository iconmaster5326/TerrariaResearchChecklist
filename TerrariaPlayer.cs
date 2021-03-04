// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using System.Collections.Generic;

namespace Kaitai
{

    /// <summary>
    /// The format for Terraria player files. This format has only been tested on
    /// Terraria 1.4 (version 234). Note that you must decrypt the file first before
    /// reading it; Terraria uses C#'s RijndaelManaged encrpytion system, with no
    /// padding, using the string &quot;h3y_gUyZ&quot; as both the key and the IV.
    /// </summary>
    public partial class TerrariaPlayer : KaitaiStruct
    {
        public static TerrariaPlayer FromFile(string fileName)
        {
            return new TerrariaPlayer(new KaitaiStream(fileName));
        }

        public TerrariaPlayer(KaitaiStream p__io, KaitaiStruct p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            _read();
        }
        private void _read()
        {
            _version = m_io.ReadS4le();
            _type = m_io.ReadU8le();
            _revision = m_io.ReadU4le();
            _favorited = m_io.ReadU8le();
            _name = new CsharpString(m_io, this, m_root);
            _difficulty = m_io.ReadU1();
            _playtime = m_io.ReadS8le();
            _hair = m_io.ReadS4le();
            _hairDye = m_io.ReadU1();
            _hideAccessories = new List<bool>((int) (16));
            for (var i = 0; i < 16; i++)
            {
                _hideAccessories.Add(m_io.ReadBitsIntBe(1) != 0);
            }
            _hideMisc = new List<bool>((int) (8));
            for (var i = 0; i < 8; i++)
            {
                _hideMisc.Add(m_io.ReadBitsIntBe(1) != 0);
            }
            m_io.AlignToByte();
            _skinVariant = m_io.ReadU1();
            _life = m_io.ReadS4le();
            _maxLife = m_io.ReadS4le();
            _mana = m_io.ReadS4le();
            _maxMana = m_io.ReadS4le();
            _hasExtraAccessorySlot = m_io.ReadU1();
            _unlockedBiomeTorches = m_io.ReadU1();
            _usingBiomeTorches = m_io.ReadU1();
            _downedDd2Event = m_io.ReadU1();
            _taxMoney = m_io.ReadS4le();
            _hairColor = new Color(m_io, this, m_root);
            _skinColor = new Color(m_io, this, m_root);
            _eyeColor = new Color(m_io, this, m_root);
            _shirtColor = new Color(m_io, this, m_root);
            _undershirtColor = new Color(m_io, this, m_root);
            _pantsColor = new Color(m_io, this, m_root);
            _shoeColor = new Color(m_io, this, m_root);
            _armor = new List<EquipmentSlot>((int) (20));
            for (var i = 0; i < 20; i++)
            {
                _armor.Add(new EquipmentSlot(m_io, this, m_root));
            }
            _dyes = new List<EquipmentSlot>((int) (10));
            for (var i = 0; i < 10; i++)
            {
                _dyes.Add(new EquipmentSlot(m_io, this, m_root));
            }
            _inventory = new List<InventorySlot>((int) (58));
            for (var i = 0; i < 58; i++)
            {
                _inventory.Add(new InventorySlot(m_io, this, m_root));
            }
            _miscEquipsAndDyes = new List<EquipmentSlot>((int) ((5 * 2)));
            for (var i = 0; i < (5 * 2); i++)
            {
                _miscEquipsAndDyes.Add(new EquipmentSlot(m_io, this, m_root));
            }
            _bank = new List<ContainerSlot>((int) (40));
            for (var i = 0; i < 40; i++)
            {
                _bank.Add(new ContainerSlot(m_io, this, m_root));
            }
            _bank2 = new List<ContainerSlot>((int) (40));
            for (var i = 0; i < 40; i++)
            {
                _bank2.Add(new ContainerSlot(m_io, this, m_root));
            }
            _bank3 = new List<ContainerSlot>((int) (40));
            for (var i = 0; i < 40; i++)
            {
                _bank3.Add(new ContainerSlot(m_io, this, m_root));
            }
            _bank4 = new List<ContainerSlot>((int) (40));
            for (var i = 0; i < 40; i++)
            {
                _bank4.Add(new ContainerSlot(m_io, this, m_root));
            }
            _voidVaultInfo = new List<bool>((int) (8));
            for (var i = 0; i < 8; i++)
            {
                _voidVaultInfo.Add(m_io.ReadBitsIntBe(1) != 0);
            }
            m_io.AlignToByte();
            _buffs = new List<Buff>((int) (22));
            for (var i = 0; i < 22; i++)
            {
                _buffs.Add(new Buff(m_io, this, m_root));
            }
            _sps = new List<Sp>();
            {
                var i = 0;
                Sp M_;
                do {
                    M_ = new Sp(m_io, this, m_root);
                    _sps.Add(M_);
                    i++;
                } while (!(M_.X == -1));
            }
            _hbLocked = m_io.ReadU1();
            _hideInfo = new List<byte>((int) (13));
            for (var i = 0; i < 13; i++)
            {
                _hideInfo.Add(m_io.ReadU1());
            }
            _anglerQuestsFinished = m_io.ReadS4le();
            _dpadRadialBindings = new List<int>((int) (4));
            for (var i = 0; i < 4; i++)
            {
                _dpadRadialBindings.Add(m_io.ReadS4le());
            }
            _builderAccStatus = new List<int>((int) (12));
            for (var i = 0; i < 12; i++)
            {
                _builderAccStatus.Add(m_io.ReadS4le());
            }
            _bartenderQuestLog = m_io.ReadS4le();
            _dead = m_io.ReadU1();
            if (Dead != 0) {
                _respawnTimer = m_io.ReadS4le();
            }
            _datetimeSaved = m_io.ReadS8le();
            _golfScore = m_io.ReadS4le();
            _nResearchesCompleted = m_io.ReadS4le();
            _researchesCompleted = new List<Research>((int) (NResearchesCompleted));
            for (var i = 0; i < NResearchesCompleted; i++)
            {
                _researchesCompleted.Add(new Research(m_io, this, m_root));
            }
            _tempItems = new List<bool>((int) (4));
            for (var i = 0; i < 4; i++)
            {
                _tempItems.Add(m_io.ReadBitsIntBe(1) != 0);
            }
            m_io.AlignToByte();
            if (TempItems[0]) {
                _tempItemMouse = new ContainerSlot(m_io, this, m_root);
            }
            if (TempItems[1]) {
                _tempItemByIndex = new ContainerSlot(m_io, this, m_root);
            }
            if (TempItems[2]) {
                _tempItemGuide = new ContainerSlot(m_io, this, m_root);
            }
            if (TempItems[3]) {
                _tempItemReforge = new ContainerSlot(m_io, this, m_root);
            }
            _creativePowers = new List<byte[]>();
            {
                var i = 0;
                while (!m_io.IsEof) {
                    _creativePowers.Add(m_io.ReadBytes(1));
                    i++;
                }
            }
        }
        public partial class Research : KaitaiStruct
        {
            public static Research FromFile(string fileName)
            {
                return new Research(new KaitaiStream(fileName));
            }

            public Research(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _item = new CsharpString(m_io, this, m_root);
                _count = m_io.ReadS4le();
            }
            private CsharpString _item;
            private int _count;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public CsharpString Item { get { return _item; } }
            public int Count { get { return _count; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class SpBody : KaitaiStruct
        {
            public static SpBody FromFile(string fileName)
            {
                return new SpBody(new KaitaiStream(fileName));
            }

            public SpBody(KaitaiStream p__io, TerrariaPlayer.Sp p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _y = m_io.ReadS4le();
                _i = m_io.ReadS4le();
                _n = new CsharpString(m_io, this, m_root);
            }
            private int _y;
            private int _i;
            private CsharpString _n;
            private TerrariaPlayer m_root;
            private TerrariaPlayer.Sp m_parent;
            public int Y { get { return _y; } }
            public int I { get { return _i; } }
            public CsharpString N { get { return _n; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer.Sp M_Parent { get { return m_parent; } }
        }
        public partial class CsharpString : KaitaiStruct
        {
            public static CsharpString FromFile(string fileName)
            {
                return new CsharpString(new KaitaiStream(fileName));
            }

            public CsharpString(KaitaiStream p__io, KaitaiStruct p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _length = new VlqBase128Le(m_io);
                _contents = System.Text.Encoding.GetEncoding("UTF-8").GetString(m_io.ReadBytes(Length.Value));
            }
            private VlqBase128Le _length;
            private string _contents;
            private TerrariaPlayer m_root;
            private KaitaiStruct m_parent;
            public VlqBase128Le Length { get { return _length; } }
            public string Contents { get { return _contents; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public KaitaiStruct M_Parent { get { return m_parent; } }
        }
        public partial class Color : KaitaiStruct
        {
            public static Color FromFile(string fileName)
            {
                return new Color(new KaitaiStream(fileName));
            }

            public Color(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _r = m_io.ReadU1();
                _g = m_io.ReadU1();
                _b = m_io.ReadU1();
            }
            private byte _r;
            private byte _g;
            private byte _b;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public byte R { get { return _r; } }
            public byte G { get { return _g; } }
            public byte B { get { return _b; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class Dummy : KaitaiStruct
        {
            public static Dummy FromFile(string fileName)
            {
                return new Dummy(new KaitaiStream(fileName));
            }

            public Dummy(KaitaiStream p__io, TerrariaPlayer.Sp p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
            }
            private TerrariaPlayer m_root;
            private TerrariaPlayer.Sp m_parent;
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer.Sp M_Parent { get { return m_parent; } }
        }
        public partial class EquipmentSlot : KaitaiStruct
        {
            public static EquipmentSlot FromFile(string fileName)
            {
                return new EquipmentSlot(new KaitaiStream(fileName));
            }

            public EquipmentSlot(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _id = m_io.ReadS4le();
                _prefix = m_io.ReadU1();
            }
            private int _id;
            private byte _prefix;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public int Id { get { return _id; } }
            public byte Prefix { get { return _prefix; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class InventorySlot : KaitaiStruct
        {
            public static InventorySlot FromFile(string fileName)
            {
                return new InventorySlot(new KaitaiStream(fileName));
            }

            public InventorySlot(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _id = m_io.ReadS4le();
                _stack = m_io.ReadS4le();
                _prefix = m_io.ReadU1();
                _favorited = m_io.ReadU1();
            }
            private int _id;
            private int _stack;
            private byte _prefix;
            private byte _favorited;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public int Id { get { return _id; } }
            public int Stack { get { return _stack; } }
            public byte Prefix { get { return _prefix; } }
            public byte Favorited { get { return _favorited; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class Sp : KaitaiStruct
        {
            public static Sp FromFile(string fileName)
            {
                return new Sp(new KaitaiStream(fileName));
            }

            public Sp(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _x = m_io.ReadS4le();
                switch (X) {
                case -1: {
                    _rest = new Dummy(m_io, this, m_root);
                    break;
                }
                default: {
                    _rest = new SpBody(m_io, this, m_root);
                    break;
                }
                }
            }
            private int _x;
            private KaitaiStruct _rest;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public int X { get { return _x; } }
            public KaitaiStruct Rest { get { return _rest; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class ContainerSlot : KaitaiStruct
        {
            public static ContainerSlot FromFile(string fileName)
            {
                return new ContainerSlot(new KaitaiStream(fileName));
            }

            public ContainerSlot(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _id = m_io.ReadS4le();
                _stack = m_io.ReadS4le();
                _prefix = m_io.ReadU1();
            }
            private int _id;
            private int _stack;
            private byte _prefix;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public int Id { get { return _id; } }
            public int Stack { get { return _stack; } }
            public byte Prefix { get { return _prefix; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        public partial class Buff : KaitaiStruct
        {
            public static Buff FromFile(string fileName)
            {
                return new Buff(new KaitaiStream(fileName));
            }

            public Buff(KaitaiStream p__io, TerrariaPlayer p__parent = null, TerrariaPlayer p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _type = m_io.ReadS4le();
                _time = m_io.ReadS4le();
            }
            private int _type;
            private int _time;
            private TerrariaPlayer m_root;
            private TerrariaPlayer m_parent;
            public int Type { get { return _type; } }
            public int Time { get { return _time; } }
            public TerrariaPlayer M_Root { get { return m_root; } }
            public TerrariaPlayer M_Parent { get { return m_parent; } }
        }
        private int _version;
        private ulong _type;
        private uint _revision;
        private ulong _favorited;
        private CsharpString _name;
        private byte _difficulty;
        private long _playtime;
        private int _hair;
        private byte _hairDye;
        private List<bool> _hideAccessories;
        private List<bool> _hideMisc;
        private byte _skinVariant;
        private int _life;
        private int _maxLife;
        private int _mana;
        private int _maxMana;
        private byte _hasExtraAccessorySlot;
        private byte _unlockedBiomeTorches;
        private byte _usingBiomeTorches;
        private byte _downedDd2Event;
        private int _taxMoney;
        private Color _hairColor;
        private Color _skinColor;
        private Color _eyeColor;
        private Color _shirtColor;
        private Color _undershirtColor;
        private Color _pantsColor;
        private Color _shoeColor;
        private List<EquipmentSlot> _armor;
        private List<EquipmentSlot> _dyes;
        private List<InventorySlot> _inventory;
        private List<EquipmentSlot> _miscEquipsAndDyes;
        private List<ContainerSlot> _bank;
        private List<ContainerSlot> _bank2;
        private List<ContainerSlot> _bank3;
        private List<ContainerSlot> _bank4;
        private List<bool> _voidVaultInfo;
        private List<Buff> _buffs;
        private List<Sp> _sps;
        private byte _hbLocked;
        private List<byte> _hideInfo;
        private int _anglerQuestsFinished;
        private List<int> _dpadRadialBindings;
        private List<int> _builderAccStatus;
        private int _bartenderQuestLog;
        private byte _dead;
        private int? _respawnTimer;
        private long _datetimeSaved;
        private int _golfScore;
        private int _nResearchesCompleted;
        private List<Research> _researchesCompleted;
        private List<bool> _tempItems;
        private ContainerSlot _tempItemMouse;
        private ContainerSlot _tempItemByIndex;
        private ContainerSlot _tempItemGuide;
        private ContainerSlot _tempItemReforge;
        private List<byte[]> _creativePowers;
        private TerrariaPlayer m_root;
        private KaitaiStruct m_parent;
        public int Version { get { return _version; } }
        public ulong Type { get { return _type; } }
        public uint Revision { get { return _revision; } }
        public ulong Favorited { get { return _favorited; } }
        public CsharpString Name { get { return _name; } }
        public byte Difficulty { get { return _difficulty; } }
        public long Playtime { get { return _playtime; } }
        public int Hair { get { return _hair; } }
        public byte HairDye { get { return _hairDye; } }

        /// <summary>
        /// Only 10 bits are currently used here.
        /// </summary>
        public List<bool> HideAccessories { get { return _hideAccessories; } }
        public List<bool> HideMisc { get { return _hideMisc; } }
        public byte SkinVariant { get { return _skinVariant; } }
        public int Life { get { return _life; } }
        public int MaxLife { get { return _maxLife; } }
        public int Mana { get { return _mana; } }
        public int MaxMana { get { return _maxMana; } }
        public byte HasExtraAccessorySlot { get { return _hasExtraAccessorySlot; } }
        public byte UnlockedBiomeTorches { get { return _unlockedBiomeTorches; } }
        public byte UsingBiomeTorches { get { return _usingBiomeTorches; } }
        public byte DownedDd2Event { get { return _downedDd2Event; } }
        public int TaxMoney { get { return _taxMoney; } }
        public Color HairColor { get { return _hairColor; } }
        public Color SkinColor { get { return _skinColor; } }
        public Color EyeColor { get { return _eyeColor; } }
        public Color ShirtColor { get { return _shirtColor; } }
        public Color UndershirtColor { get { return _undershirtColor; } }
        public Color PantsColor { get { return _pantsColor; } }
        public Color ShoeColor { get { return _shoeColor; } }
        public List<EquipmentSlot> Armor { get { return _armor; } }
        public List<EquipmentSlot> Dyes { get { return _dyes; } }
        public List<InventorySlot> Inventory { get { return _inventory; } }
        public List<EquipmentSlot> MiscEquipsAndDyes { get { return _miscEquipsAndDyes; } }
        public List<ContainerSlot> Bank { get { return _bank; } }
        public List<ContainerSlot> Bank2 { get { return _bank2; } }
        public List<ContainerSlot> Bank3 { get { return _bank3; } }
        public List<ContainerSlot> Bank4 { get { return _bank4; } }
        public List<bool> VoidVaultInfo { get { return _voidVaultInfo; } }
        public List<Buff> Buffs { get { return _buffs; } }
        public List<Sp> Sps { get { return _sps; } }
        public byte HbLocked { get { return _hbLocked; } }
        public List<byte> HideInfo { get { return _hideInfo; } }
        public int AnglerQuestsFinished { get { return _anglerQuestsFinished; } }
        public List<int> DpadRadialBindings { get { return _dpadRadialBindings; } }
        public List<int> BuilderAccStatus { get { return _builderAccStatus; } }
        public int BartenderQuestLog { get { return _bartenderQuestLog; } }
        public byte Dead { get { return _dead; } }
        public int? RespawnTimer { get { return _respawnTimer; } }
        public long DatetimeSaved { get { return _datetimeSaved; } }
        public int GolfScore { get { return _golfScore; } }
        public int NResearchesCompleted { get { return _nResearchesCompleted; } }
        public List<Research> ResearchesCompleted { get { return _researchesCompleted; } }
        public List<bool> TempItems { get { return _tempItems; } }
        public ContainerSlot TempItemMouse { get { return _tempItemMouse; } }
        public ContainerSlot TempItemByIndex { get { return _tempItemByIndex; } }
        public ContainerSlot TempItemGuide { get { return _tempItemGuide; } }
        public ContainerSlot TempItemReforge { get { return _tempItemReforge; } }

        /// <summary>
        /// TODO
        /// </summary>
        public List<byte[]> CreativePowers { get { return _creativePowers; } }
        public TerrariaPlayer M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
