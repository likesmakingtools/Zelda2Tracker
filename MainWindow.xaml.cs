using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
button = new Button();
button.Content = "Hover over me.";
tt = new ToolTip();
tt.Content = "Created with C#";
button.ToolTip = tt;
cv2.Children.Add(button);
 * */

namespace Zelda2Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
        private readonly SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);
        private readonly SolidColorBrush yellowBrush = new SolidColorBrush(Colors.Yellow);
        private readonly SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush blueBrush = new SolidColorBrush(Colors.Blue);
        private readonly SolidColorBrush grayBrush = new SolidColorBrush(Colors.Gray);

        private readonly int mapBaseX = 205; // 16 -> 3280, 8 -> 1640
        private readonly int mapBaseY = 234; // 16 -> 3744, 8 -> 1872
        private readonly int palace01BaseX = 258;
        private readonly int palace01BaseY = 66;
        private readonly int palace02BaseX = 290;
        private readonly int palace02BaseY = 114;
        private readonly int palace03BaseX = 258;
        private readonly int palace03BaseY = 82;
        private readonly int palace04BaseX = 202;
        private readonly int palace04BaseY = 114;
        private readonly int palace05BaseX = 266;
        private readonly int palace05BaseY = 130;
        private readonly int palace06BaseX = 370;
        private readonly int palace06BaseY = 130;
        private readonly int palace07BaseX = 442;
        private readonly int palace07BaseY = 242;
        private int mapUnits = 8;
        private int mapOffset = -4;
        private int palaceUnits = 6;

        private CollectibleList AllCollectibles = new CollectibleList();
        private List<List<Ellipse>> AllEllipses = new List<List<Ellipse>>();
        private MyStuff items = new MyStuff();
        private Point oldMousePosition = new Point();

        public MainWindow()
        {
            InitializeComponent();
            SetMapCanvasSize();
            InitializeAllEllipses();
        }

        private void SetMapCanvasSize()
        {
            cnvMap.Width = mapBaseX * mapUnits;
            cnvMap.Height = mapBaseY * mapUnits;
            imgMap.Width = mapBaseX * mapUnits;
            imgMap.Height = mapBaseY * mapUnits;

            cnvPalace01.Width = palace01BaseX * palaceUnits;
            cnvPalace01.Height = palace01BaseY * palaceUnits;
            imgPalace01.Width = palace01BaseX * palaceUnits;
            imgPalace01.Height = palace01BaseY * palaceUnits;

            cnvPalace02.Width = palace02BaseX * palaceUnits;
            cnvPalace02.Height = palace02BaseY * palaceUnits;
            imgPalace02.Width = palace02BaseX * palaceUnits;
            imgPalace02.Height = palace02BaseY * palaceUnits;

            cnvPalace03.Width = palace03BaseX * palaceUnits;
            cnvPalace03.Height = palace03BaseY * palaceUnits;
            imgPalace03.Width = palace03BaseX * palaceUnits;
            imgPalace03.Height = palace03BaseY * palaceUnits;

            cnvPalace04.Width = palace04BaseX * palaceUnits;
            cnvPalace04.Height = palace04BaseY * palaceUnits;
            imgPalace04.Width = palace04BaseX * palaceUnits;
            imgPalace04.Height = palace04BaseY * palaceUnits;

            cnvPalace05.Width = palace05BaseX * palaceUnits;
            cnvPalace05.Height = palace05BaseY * palaceUnits;
            imgPalace05.Width = palace05BaseX * palaceUnits;
            imgPalace05.Height = palace05BaseY * palaceUnits;

            cnvPalace06.Width = palace06BaseX * palaceUnits;
            cnvPalace06.Height = palace06BaseY * palaceUnits;
            imgPalace06.Width = palace06BaseX * palaceUnits;
            imgPalace06.Height = palace06BaseY * palaceUnits;

            cnvPalace07.Width = palace07BaseX * palaceUnits;
            cnvPalace07.Height = palace07BaseY * palaceUnits;
            imgPalace07.Width = palace07BaseX * palaceUnits;
            imgPalace07.Height = palace07BaseY * palaceUnits;
        }

        private void InitializeAllEllipses()
        {
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());
            AllEllipses.Add(new List<Ellipse>());

            InitializeEllipses(0); // World Map
            InitializeEllipses(1); // Palace 01
            InitializeEllipses(2); // Palace 02
            InitializeEllipses(3); // Palace 03
            InitializeEllipses(4); // Palace 04
            InitializeEllipses(5); // Palace 05
            InitializeEllipses(6); // Palace 06
            InitializeEllipses(7); // Palace 07
        }

        private void InitializeEllipses(int index)
        {
            if (index < 0 || index > 7) return;

            int units, offset;
            List<Collectible> collectibles = new List<Collectible>();
            Canvas canvas = new Canvas();

            if (index == 0)
            {
                collectibles = AllCollectibles.MapCollectibles;
                canvas = cnvMap;
                units = mapUnits;
                offset = mapOffset;
            }
            else { units = palaceUnits; offset = 0; }
            if (index == 1) { collectibles = AllCollectibles.Palace01Collectibles; canvas = cnvPalace01; }
            if (index == 2) { collectibles = AllCollectibles.Palace02Collectibles; canvas = cnvPalace02; }
            if (index == 3) { collectibles = AllCollectibles.Palace03Collectibles; canvas = cnvPalace03; }
            if (index == 4) { collectibles = AllCollectibles.Palace04Collectibles; canvas = cnvPalace04; }
            if (index == 5) { collectibles = AllCollectibles.Palace05Collectibles; canvas = cnvPalace05; }
            if (index == 6) { collectibles = AllCollectibles.Palace06Collectibles; canvas = cnvPalace06; }
            if (index == 7) { collectibles = AllCollectibles.Palace07Collectibles; canvas = cnvPalace07; }

            foreach (Collectible collectible in collectibles)
            {
                Ellipse e = new Ellipse();
                e.Name = collectible.ID;
                Canvas.SetLeft(e, (collectible.X * units) + offset);
                Canvas.SetTop(e, (collectible.Y * units) + offset);
                e.Width = units * 2;
                e.Height = units * 2;
                e.Stroke = blackBrush;
                e.StrokeThickness = 2;
                if (index == 0)
                {
                    e.Fill = (collectible.inGroup || collectible.inPalace) ? blueBrush : (collectible.canCollect) ? greenBrush : redBrush;
                }
                else
                {
                    e.Fill = (collectible.canCollect) ? greenBrush : redBrush;
                }
                
                e.Opacity = 1;
                e.MouseLeftButtonDown += Ellipse_LeftClick;
                e.MouseRightButtonDown += Ellipse_RightClick;
                Panel.SetZIndex(e, 1);

                ToolTip tt = new ToolTip();
                tt.StaysOpen = true;

                if (collectible.inGroup)
                {
                    tt.Content = BuildGroupedContent(collectible.GroupID);
                }
                else
                {
                    tt.Content = collectible.GetTooltip();
                }
                
                e.ToolTip = tt;

                canvas.Children.Add(e);
                AllEllipses[index].Add(e);
            }
        }

        private void btnBig_Click(object sender, RoutedEventArgs e)
        {
            mapUnits = 16;
            mapOffset = -8;
            palaceUnits = 8;
            ResizeMaps();
        }

        private void btnSmall_Click(object sender, RoutedEventArgs e)
        {
            mapUnits = 8;
            mapOffset = -4;
            palaceUnits = 6;
            ResizeMaps();
        }

        private void ResizeMaps()
        {
            SetMapCanvasSize();
            ResizeMap(0);
            ResizeMap(1);
            ResizeMap(2);
            ResizeMap(3);
            ResizeMap(4);
            ResizeMap(5);
            ResizeMap(6);
            ResizeMap(7);
        }

        private void ResizeMap(int index)
        {
            if (index < 0 || index > 7) return;

            int units, offset;
            if (index == 0) { units = mapUnits; offset = mapOffset; }
            else { units = palaceUnits; offset = 0; }

            foreach (Ellipse e in AllEllipses[index])
            {
                Collectible item = AllCollectibles.FindCollectible(e.Name, index);
                if (item == null) continue;

                Canvas.SetLeft(e, (item.X * units) + offset);
                Canvas.SetTop(e, (item.Y * units) + offset);
                e.Width = units * 2;
                e.Height = units * 2;
            }
        }

        private void imgMap_MouseMove(object sender, MouseEventArgs e)
        {
            Image image = (Image)sender;
            Canvas canvas = (Canvas)image.Parent;
            ScrollViewer sv = (ScrollViewer)canvas.Parent;
            Point newMousePosition = Mouse.GetPosition((Image)sender);

            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (newMousePosition.Y < oldMousePosition.Y)
                    sv.ScrollToVerticalOffset(sv.VerticalOffset + 1);
                if (newMousePosition.Y > oldMousePosition.Y)
                    sv.ScrollToVerticalOffset(sv.VerticalOffset - 1);

                if (newMousePosition.X < oldMousePosition.X)
                    sv.ScrollToHorizontalOffset(sv.HorizontalOffset + 1);
                if (newMousePosition.X > oldMousePosition.X)
                    sv.ScrollToHorizontalOffset(sv.HorizontalOffset - 1);
            }
            else
            {
                oldMousePosition = newMousePosition;
            }
        }

        public void Ellipse_LeftClick(object sender, MouseButtonEventArgs e)
        {
            // Mark Item as Collected
            Ellipse ellipse = (Ellipse)sender;
            SolidColorBrush brush = (SolidColorBrush)ellipse.Fill;

            if (brush.Color == greenBrush.Color)
            {
                Collectible item = AllCollectibles.FindCollectible(ellipse.Name);
                if (item != null)
                {
                    item.isCollected = true;

                    ToolTip tt = new ToolTip();
                    if (item.inGroup)
                    {
                        tt.Content = BuildGroupedContent(item.GroupID);
                    }
                    else
                    {
                        tt.Content = item.GetTooltip();
                    }

                    ellipse.Fill = grayBrush;
                    ellipse.ToolTip = tt;
                }
            }
        }

        private void Ellipse_RightClick(object sender, MouseButtonEventArgs e)
        {
            // Mark Item as Uncollected
            Ellipse ellipse = (Ellipse)sender;
            SolidColorBrush brush = (SolidColorBrush)ellipse.Fill;

            if (brush.Color == grayBrush.Color)
            {
                Collectible item = AllCollectibles.FindCollectible(ellipse.Name);
                if (item != null)
                {
                    item.isCollected = false;

                    ToolTip tt = new ToolTip();
                    if (item.inGroup)
                    {
                        tt.Content = BuildGroupedContent(item.GroupID);
                    }
                    else
                    {
                        tt.Content = item.GetTooltip();
                    }

                    ellipse.Fill = greenBrush;
                    ellipse.ToolTip = tt;
                }
            }
        }

        private void Items_LeftClick(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            string itemName = string.Empty;
            string imageUri = string.Empty;

            switch (image.Name)
            {
                case "itmCandle": items.Candle = !items.Candle; itemName = (items.Candle) ? "Item_Candle" : "Item_Candle_Off"; break;
                case "itmGlove": items.Glove = !items.Glove; itemName = (items.Glove) ? "Item_Glove" : "Item_Glove_Off"; break;
                case "itmRaft": items.Raft = !items.Raft; itemName = (items.Raft) ? "Item_Raft" : "Item_Raft_Off"; break;
                case "itmBoots": items.Boots = !items.Boots; itemName = (items.Boots) ? "Item_Boots" : "Item_Boots_Off"; break;
                case "itmFlute": items.Flute = !items.Flute; itemName = (items.Flute) ? "Item_Flute" : "Item_Flute_Off"; break;
                case "itmCross": items.Cross = !items.Cross; itemName = (items.Cross) ? "Item_Cross" : "Item_Cross_Off"; break;
                case "itmHammer": items.Hammer = !items.Hammer; itemName = (items.Hammer) ? "Item_Hammer" : "Item_Hammer_Off"; break;
                case "itmBracelet": items.Bracelet = !items.Bracelet; itemName = (items.Bracelet) ? "Item_Bracelet" : "Item_Bracelet_Off"; break;
                case "itmFairy": items.FairyItem = !items.FairyItem; itemName = (items.FairyItem) ? "Item_Fairy" : "Item_Fairy_Off"; break;
                case "itmAKey": items.AKey = !items.AKey; itemName = (items.AKey) ? "Item_AKey" : "Item_AKey_Off"; break;
                case "itmBook": items.Book = !items.Book; itemName = (items.Book) ? "Item_Book" : "Item_Book_Off"; break;
                case "itmLetter": items.Letter = !items.Letter; itemName = (items.Letter) ? "Item_Letter" : "Item_Letter_Off"; break;
                case "itmMirror": items.Mirror = !items.Mirror; itemName = (items.Mirror) ? "Item_Mirror" : "Item_Mirror_Off"; break;
                case "itmTrophy": items.Trophy = !items.Trophy; itemName = (items.Trophy) ? "Item_Trophy" : "Item_Trophy_Off"; break;
                case "itmFlower": items.Flower = !items.Flower; itemName = (items.Flower) ? "Item_Flower" : "Item_Flower_Off"; break;
                case "itmKid": items.Kid = !items.Kid; itemName = (items.Kid) ? "Item_Kid" : "Item_Kid_Off"; break;
                case "sklDownthrust": items.Downthrust = !items.Downthrust; itemName = (items.Downthrust) ? "Skill_Downthrust" : "Skill_Downthrust_Off"; break;
                case "sklUpthrust": items.Upthrust = !items.Upthrust; itemName = (items.Upthrust) ? "Skill_Upthrust" : "Skill_Upthrust_Off"; break;
                case "splProtect": items.Protect = !items.Protect; itemName = (items.Protect) ? "Spell_Protect" : "Spell_Protect_Off"; break;
                case "splJump": items.Jump = !items.Jump; itemName = (items.Jump) ? "Spell_Jump" : "Spell_Jump_Off"; break;
                case "splHeal": items.Heal = !items.Heal; itemName = (items.Heal) ? "Spell_Heal" : "Spell_Heal_Off"; break;
                case "splFairy": items.FairySpell = !items.FairySpell; itemName = (items.FairySpell) ? "Spell_Fairy" : "Spell_Fairy_Off"; break;
                case "splFire": items.Fire = !items.Fire; itemName = (items.Fire) ? "Spell_Fire" : "Spell_Fire_Off"; break;
                case "splReflect": items.Reflect = !items.Reflect; itemName = (items.Reflect) ? "Spell_Reflect" : "Spell_Reflect_Off"; break;
                case "splEnigma": items.Enigma = !items.Enigma; itemName = (items.Enigma) ? "Spell_Enigma" : "Spell_Enigma_Off"; break;
                case "splThunder": items.Thunder = !items.Thunder; itemName = (items.Thunder) ? "Spell_Thunder" : "Spell_Thunder_Off"; break;
                case "gemPalace1": items.P1Gem = !items.P1Gem; itemName = (items.P1Gem) ? "Gem" : "Gem_Off"; break;
                case "gemPalace2": items.P2Gem = !items.P2Gem; itemName = (items.P2Gem) ? "Gem" : "Gem_Off"; break;
                case "gemPalace3": items.P3Gem = !items.P3Gem; itemName = (items.P3Gem) ? "Gem" : "Gem_Off"; break;
                case "gemPalace4": items.P4Gem = !items.P4Gem; itemName = (items.P4Gem) ? "Gem" : "Gem_Off"; break;
                case "gemPalace5": items.P5Gem = !items.P5Gem; itemName = (items.P5Gem) ? "Gem" : "Gem_Off"; break;
                case "gemPalace6": items.P6Gem = !items.P6Gem; itemName = (items.P6Gem) ? "Gem" : "Gem_Off"; break;
                default: break;
            }

            imageUri = "/Images/" + itemName + ".png";
            image.Source = new BitmapImage(new Uri(imageUri, UriKind.Relative));

            UpdateCollectibility();
        }

        private void Areas_LeftClick(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            int y = 0;

            svMap.Visibility = Visibility.Collapsed;
            svPalace01.Visibility = Visibility.Collapsed;
            svPalace02.Visibility = Visibility.Collapsed;
            svPalace03.Visibility = Visibility.Collapsed;
            svPalace04.Visibility = Visibility.Collapsed;
            svPalace05.Visibility = Visibility.Collapsed;
            svPalace06.Visibility = Visibility.Collapsed;
            svPalace07.Visibility = Visibility.Collapsed;

            switch (image.Name)
            {
                case "mapWorld": y = 3; svMap.Visibility = Visibility.Visible; break;
                case "mapPalace01": y = 37; svPalace01.Visibility = Visibility.Visible; break;
                case "mapPalace02": y = 71; svPalace02.Visibility = Visibility.Visible; break;
                case "mapPalace03": y = 105; svPalace03.Visibility = Visibility.Visible; break;
                case "mapPalace04": y = 139; svPalace04.Visibility = Visibility.Visible; break;
                case "mapPalace05": y = 173; svPalace05.Visibility = Visibility.Visible; break;
                case "mapPalace06": y = 207; svPalace06.Visibility = Visibility.Visible; break;
                case "mapPalace07": y = 241; svPalace07.Visibility = Visibility.Visible; break;
                default: break;
            }

            Canvas.SetTop(mapSelection, y);
        }

        private void Collections_LeftClick(object sender, MouseButtonEventArgs e)
        {
            // increase count
            Image image = (Image)sender;

            IncrementCollection(image.Name, 1);
        }

        private void Collections_RightClick(object sender, MouseButtonEventArgs e)
        {
            // decrease count
            Image image = (Image)sender;

            IncrementCollection(image.Name, -1);
        }

        private void IncrementCollection(string name, int count)
        {
            switch (name)
            {
                case "colLinkDolls": items.Lives += count; cntLinkDolls.Source = new BitmapImage(new Uri($"/Images/_{items.Lives}.png", UriKind.Relative)); break;
                case "colP1Keys": items.P1Keys += count; cntP1Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P1Keys}.png", UriKind.Relative)); break;
                case "colP2Keys": items.P2Keys += count; cntP2Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P2Keys}.png", UriKind.Relative)); break;
                case "colP3Keys": items.P3Keys += count; cntP3Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P3Keys}.png", UriKind.Relative)); break;
                case "colP4Keys": items.P4Keys += count; cntP4Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P4Keys}.png", UriKind.Relative)); break;
                case "colP5Keys": items.P5Keys += count; cntP5Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P5Keys}.png", UriKind.Relative)); break;
                case "colP6Keys": items.P6Keys += count; cntP6Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P6Keys}.png", UriKind.Relative)); break;
                case "colSlimes": items.Slimes += count; cntSlimes.Source = new BitmapImage(new Uri($"/Images/_{items.Slimes}.png", UriKind.Relative)); break;
                default: break;
            }

            UpdateCollectibility();
        }


        private void UpdateCollectibility()
        {
            AllCollectibles.UpdateAllCollectibility(ref items);

            foreach (List<Ellipse> ellipses in AllEllipses)
            {
                foreach (Ellipse e in ellipses)
                {
                    Collectible item = AllCollectibles.FindCollectible(e.Name);
                    if (item == null) continue;
                    bool allCollectible = false, anyCollectible = false, uncollectible = item.IsUncollectible();

                    if (uncollectible)
                    {
                        if (item.inPalace)
                        {
                            AllCollectibles.AllCollectibleInPalace(item.PalaceID, out allCollectible, out anyCollectible);
                        }
                        else
                        {
                            AllCollectibles.AllCollectibleInGroup(item.GroupID, out allCollectible, out anyCollectible);
                        }
                    }

                    if (!item.isCollected)
                    {
                        if (item.canCollect || (uncollectible && allCollectible))
                        {
                            e.Fill = greenBrush;
                        }
                        else if (uncollectible && anyCollectible)
                        {
                            e.Fill = yellowBrush;
                        }
                        else if (uncollectible)
                        {
                            e.Fill = blueBrush;
                        }
                        else
                        {
                            e.Fill = redBrush;
                        }
                    }
                    else
                    {
                        e.Fill = grayBrush;
                    }

                    if (item.inGroup && item.ID == item.GroupID)
                    {
                        ToolTip tt = new ToolTip();
                        tt.Content = BuildGroupedContent(item.GroupID);
                        e.ToolTip = tt;
                    }
                    
                }
            }
        }

        private StackPanel BuildGroupedContent(string groupID)
        {
            StackPanel panel = new();
            Grid grid = new();
            ColumnDefinition column1 = new();
            ColumnDefinition column2 = new();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);

            List<Collectible> collectibles = AllCollectibles.GetGroupedCollectibles(groupID);
            int rowIndex = 0;

            foreach (Collectible collectible in collectibles)
            {
                RowDefinition row = new();
                grid.RowDefinitions.Add(row);

                Ellipse ellipse = new()
                {
                    Fill = (collectible.isCollected) ? grayBrush : (collectible.canCollect) ? greenBrush : redBrush,
                    Stroke = blackBrush,
                    StrokeThickness = 2,
                    Width = mapUnits * 2,
                    Height = mapUnits * 2
                };
                //ellipse.MouseLeftButtonDown += Ellipse_LeftClick;
                //ellipse.MouseRightButtonDown += Ellipse_RightClick;

                TextBlock textBlock = new()
                {
                    Text = collectible.GetTooltip()
                };

                Grid.SetColumn(ellipse, 0);
                Grid.SetRow(ellipse, rowIndex);
                Grid.SetColumn(textBlock, 1);
                Grid.SetRow(textBlock, rowIndex);

                grid.Children.Add(ellipse);
                grid.Children.Add(textBlock);

                rowIndex++;
            }

            panel.Children.Add(grid);

            return panel;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MyData data = new(items, AllCollectibles.GetAllItemData());
            string jsonString = JsonSerializer.Serialize(data);
            string filename = string.Empty;

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "MyData";
            dlg.DefaultExt = ".json";
            dlg.Filter = "Json files (.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                File.WriteAllText(filename, jsonString);
            }

            Console.WriteLine(jsonString);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            MyData? data = null;
            string filename = string.Empty;
            string jsonString = string.Empty;

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".json";
            dlg.Filter = "Json files (.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    jsonString = reader.ReadToEnd();
                }
                data = JsonSerializer.Deserialize<MyData>(jsonString);
            }

            if (data != null)
            {
                items = data.Stuff;
                AllCollectibles.LoadItemData(data.Items);
                UpdateImagesAfterLoad();
            }

            Console.WriteLine(jsonString);
        }

        private void UpdateImagesAfterLoad()
        {
            string on = "", off = "_Off";

            // Items
            itmCandle.Source = new BitmapImage(new Uri($"/Images/Item_Candle{(items.Candle ? on : off)}.png", UriKind.Relative));
            itmGlove.Source = new BitmapImage(new Uri($"/Images/Item_Glove{(items.Glove ? on : off)}.png", UriKind.Relative));
            itmRaft.Source = new BitmapImage(new Uri($"/Images/Item_Raft{(items.Raft ? on : off)}.png", UriKind.Relative));
            itmBoots.Source = new BitmapImage(new Uri($"/Images/Item_Boots{(items.Boots ? on : off)}.png", UriKind.Relative));
            itmFlute.Source = new BitmapImage(new Uri($"/Images/Item_Flute{(items.Flute ? on : off)}.png", UriKind.Relative));
            itmCross.Source = new BitmapImage(new Uri($"/Images/Item_Cross{(items.Cross ? on : off)}.png", UriKind.Relative));
            itmHammer.Source = new BitmapImage(new Uri($"/Images/Item_Hammer{(items.Hammer ? on : off)}.png", UriKind.Relative));
            itmBracelet.Source = new BitmapImage(new Uri($"/Images/Item_Bracelet{(items.Bracelet ? on : off)}.png", UriKind.Relative));
            itmFairy.Source = new BitmapImage(new Uri($"/Images/Item_Fairy{(items.FairyItem ? on : off)}.png", UriKind.Relative));
            itmAKey.Source = new BitmapImage(new Uri($"/Images/Item_AKey{(items.AKey ? on : off)}.png", UriKind.Relative));
            itmBook.Source = new BitmapImage(new Uri($"/Images/Item_Book{(items.Book ? on : off)}.png", UriKind.Relative));
            itmLetter.Source = new BitmapImage(new Uri($"/Images/Item_Letter{(items.Letter ? on : off)}.png", UriKind.Relative));
            itmMirror.Source = new BitmapImage(new Uri($"/Images/Item_Mirror{(items.Mirror ? on : off)}.png", UriKind.Relative));
            itmTrophy.Source = new BitmapImage(new Uri($"/Images/Item_Trophy{(items.Trophy ? on : off)}.png", UriKind.Relative));
            itmFlower.Source = new BitmapImage(new Uri($"/Images/Item_Flower{(items.Flower ? on : off)}.png", UriKind.Relative));
            itmKid.Source = new BitmapImage(new Uri($"/Images/Item_Kid{(items.Kid ? on : off)}.png", UriKind.Relative));
            
            // Spells
            splProtect.Source = new BitmapImage(new Uri($"/Images/Spell_Protect{(items.Protect ? on : off)}.png", UriKind.Relative));
            splJump.Source = new BitmapImage(new Uri($"/Images/Spell_Jump{(items.Jump ? on : off)}.png", UriKind.Relative));
            splHeal.Source = new BitmapImage(new Uri($"/Images/Spell_Heal{(items.Heal ? on : off)}.png", UriKind.Relative));
            splFairy.Source = new BitmapImage(new Uri($"/Images/Spell_Fairy{(items.FairySpell ? on : off)}.png", UriKind.Relative));
            splFire.Source = new BitmapImage(new Uri($"/Images/Spell_Fire{(items.Fire ? on : off)}.png", UriKind.Relative));
            splReflect.Source = new BitmapImage(new Uri($"/Images/Spell_Reflect{(items.Reflect ? on : off)}.png", UriKind.Relative));
            splEnigma.Source = new BitmapImage(new Uri($"/Images/Spell_Enigma{(items.Enigma ? on : off)}.png", UriKind.Relative));
            splThunder.Source = new BitmapImage(new Uri($"/Images/Spell_Thunder{(items.Thunder ? on : off)}.png", UriKind.Relative));

            // Skills
            sklDownthrust.Source = new BitmapImage(new Uri($"/Images/Skill_Downthrust{(items.Downthrust ? on : off)}.png", UriKind.Relative));
            sklUpthrust.Source = new BitmapImage(new Uri($"/Images/Skill_Upthrust{(items.Upthrust ? on : off)}.png", UriKind.Relative));

            // Palace Gems
            gemPalace1.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P1Gem ? on : off)}.png", UriKind.Relative));
            gemPalace2.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P2Gem ? on : off)}.png", UriKind.Relative));
            gemPalace3.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P3Gem ? on : off)}.png", UriKind.Relative));
            gemPalace4.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P4Gem ? on : off)}.png", UriKind.Relative));
            gemPalace5.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P5Gem ? on : off)}.png", UriKind.Relative));
            gemPalace6.Source = new BitmapImage(new Uri($"/Images/Gem{(items.P6Gem ? on : off)}.png", UriKind.Relative));

            // Counters
            cntLinkDolls.Source = new BitmapImage(new Uri($"/Images/_{items.Lives}.png", UriKind.Relative));
            cntP1Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P1Keys}.png", UriKind.Relative));
            cntP2Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P2Keys}.png", UriKind.Relative));
            cntP3Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P3Keys}.png", UriKind.Relative));
            cntP4Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P4Keys}.png", UriKind.Relative));
            cntP5Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P5Keys}.png", UriKind.Relative));
            cntP6Keys.Source = new BitmapImage(new Uri($"/Images/_{items.P6Keys}.png", UriKind.Relative));
            cntSlimes.Source = new BitmapImage(new Uri($"/Images/_{items.Slimes}.png", UriKind.Relative));

            UpdateCollectibility();
        }
    }
}