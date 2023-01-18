using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Yaskawa.Ext;

namespace DemoExtension21_csharp
{
    class demoExtension21_csharp
    {
        private demoExtension21_csharp() 
        {
            var _version = new Yaskawa.Ext.Version(2, 1, 0);
            var _languages = new HashSet<string> { "en", "ja" };


            extension = new Extension("com.yaskawa.yii.demoextension.ext", _version, "Yaskawa", _languages, "10.0.0.4", 10080);
            Console.WriteLine("API version: " + extension.apiVersion());

            pendant = extension.pendant();
            controller = extension.controller();
            Console.WriteLine("Controller software version:" + controller.softwareVersion());
        }

        protected Extension extension;
        protected Pendant pendant;
        protected Controller controller;
        protected bool run = true;
        protected bool update = false;
        protected double time;

        public void setup()
        {
            //Add setup stuff here

            Console.WriteLine($"Environment.Version: {Environment.Version}");
            Console.WriteLine($"RuntimeInformation.FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"RuntimeInformation.RuntimeIdentifier: {RuntimeInformation.RuntimeIdentifier}");
            Console.WriteLine(System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(int).Assembly.Location).ProductVersion);
        }

        public void Run()
        {
            //Register YML Files
            pendant.registerYMLFile("DemoTab.yml");
            pendant.registerYMLFile("DemoWindow.yml");
            // --- Register YML ---

            // Main Menu
            pendant.registerYMLFile("yml/Introduction.yml");
            // Cell Operation
            pendant.registerYMLFile("yml/CellOperation.yml");
            // Products
            pendant.registerYMLFile("yml/ManageProducts.yml");
            // Pick/Place Job
            pendant.registerYMLFile("yml/ManageJobs.yml");
            pendant.registerYMLFile("yml/EditorPickPlace.yml");
            pendant.registerYMLFile("yml/BoxControl.yml");
            pendant.registerYMLFile("yml/AutoPack.yml");
            pendant.registerYMLFile("yml/AutoSequence.yml");
            pendant.registerYMLFile("yml/EditorLayer.yml");
            pendant.registerYMLFile("yml/EditorPath.yml");
            // Build Pattern
            pendant.registerYMLFile("yml/ManageBuilds.yml");
            pendant.registerYMLFile("yml/EditorBuild.yml");
            // Setup
            pendant.registerYMLFile("yml/NewStationSelect.yml");
            pendant.registerYMLFile("yml/CellSetup.yml");
            pendant.registerYMLFile("yml/ManageStations.yml");
            pendant.registerYMLFile("yml/ManageGrippers.yml");
            // Wizard
            pendant.registerYMLFile("yml/Wizard.yml");
            pendant.registerYMLFile("yml/WizardSetup.yml");

            // Main UI
            pendant.registerYMLFile("yml/PalletizingExt.yml");

            // --- Register Images ---
            pendant.registerImageFile("images/AppImage.svg");

            // Intro images
            pendant.registerImageFile("images/LeftArrow.png");
            pendant.registerImageFile("images/back_arrow@2x.png");    // not used?
            pendant.registerImageFile("images/GradientButton.svg");
            pendant.registerImageFile("images/GearIcon.svg");
            pendant.registerImageFile("images/warning_icon.png");
            pendant.registerImageFile("images/YASKAWA-logo-blue.svg");

            pendant.registerImageFile("images/TabHome.png");
            pendant.registerImageFile("images/TabCellOperation.png");
            pendant.registerImageFile("images/TabProduct.png");
            pendant.registerImageFile("images/TabPick.png");
            pendant.registerImageFile("images/TabPlace.png");
            pendant.registerImageFile("images/TabBuild.png");
            pendant.registerImageFile("images/TabCellSetup.png");
            pendant.registerImageFile("images/PageShadow.png");

            // Cell Operation 
            pendant.registerImageFile("images/Stop_Icon.png");
            pendant.registerImageFile("images/Play_IconG.png");
            pendant.registerImageFile("images/Play_IconG-0.png");
            pendant.registerImageFile("images/Play_IconG-20.png");
            pendant.registerImageFile("images/Play_IconG-40.png");
            pendant.registerImageFile("images/Play_IconG-60.png");
            pendant.registerImageFile("images/Play_IconG-80.png");
            pendant.registerImageFile("images/Pause_Icon.png");

            // Station Images
            pendant.registerImageFile("images/StationBuild.png");
            pendant.registerImageFile("images/StationInfeed.png");
            pendant.registerImageFile("images/InfeedAlignRight.png");
            pendant.registerImageFile("images/InfeedAlignCenter.png");
            pendant.registerImageFile("images/InfeedAlignLeft.png");
            pendant.registerImageFile("images/StationDispenserFixedPick.png");
            pendant.registerImageFile("images/StationDispenserSearchStack.png");

            // Product Images
            pendant.registerImageFile("images/ProductBox.png");
            pendant.registerImageFile("images/ProductSeparator.png");
            pendant.registerImageFile("images/ProductPallet.png");

            // Path Editor Images
            pendant.registerImageFile("images/PathInfeedApproach.png");
            pendant.registerImageFile("images/PathInfeedPick.png");
            pendant.registerImageFile("images/PathInfeedDepart.png");
            pendant.registerImageFile("images/PathDispenserFixApproach.png");
            pendant.registerImageFile("images/PathDispenserFixPick.png");
            pendant.registerImageFile("images/PathDispenserFixDepart.png");
            pendant.registerImageFile("images/PathDispenserFixApproachPallet.png");
            pendant.registerImageFile("images/PathDispenserFixPickPallet.png");
            pendant.registerImageFile("images/PathDispenserFixDepartPallet.png");
            pendant.registerImageFile("images/PathDispenserStackApproach.png");
            pendant.registerImageFile("images/PathDispenserStackPick.png");
            pendant.registerImageFile("images/PathDispenserStackDepart1.png");
            pendant.registerImageFile("images/PathDispenserStackDepart.png");
            pendant.registerImageFile("images/PathDispenserStackApproachPallet.png");
            pendant.registerImageFile("images/PathDispenserStackPickPallet.png");
            pendant.registerImageFile("images/PathDispenserStackDepart1Pallet.png");
            pendant.registerImageFile("images/PathDispenserStackDepartPallet.png");
            pendant.registerImageFile("images/PathBuildApproachBox.png");
            pendant.registerImageFile("images/PathBuildPlaceBox.png");
            pendant.registerImageFile("images/PathBuildDepartBox.png");
            pendant.registerImageFile("images/PathBuildApproachSeparator.png");
            pendant.registerImageFile("images/PathBuildPlaceSeparator.png");
            pendant.registerImageFile("images/PathBuildDepartSeparator.png");
            pendant.registerImageFile("images/PathBuildApproachPallet.png");
            pendant.registerImageFile("images/PathBuildPlacePallet.png");
            pendant.registerImageFile("images/PathBuildDepartPallet.png");

            // Layer Editor Images
            pendant.registerImageFile("images/CenterView.png");
            pendant.registerImageFile("images/Fullscreen.png");
            pendant.registerImageFile("images/ZoomOut.png");
            pendant.registerImageFile("images/ZoomIn.png");
            pendant.registerImageFile("images/CenterBox.png");
            pendant.registerImageFile("images/UpArrowButton.svg");
            pendant.registerImageFile("images/DownArrowButton.svg");
            pendant.registerImageFile("images/LeftArrowButton.svg");
            pendant.registerImageFile("images/RightArrowButton.svg");
            pendant.registerImageFile("images/RotateClockwise.svg");
            pendant.registerImageFile("images/RotateCounterClockWise.svg");
            pendant.registerImageFile("images/StepMarker.svg");
            pendant.registerImageFile("images/MirrorHoriz.svg");
            pendant.registerImageFile("images/MirrorVert.svg");
            pendant.registerImageFile("images/Pinwheel1.svg");
            pendant.registerImageFile("images/Pinwheel2.svg");
            pendant.registerImageFile("images/Delete.svg");
            pendant.registerImageFile("images/AutoSeqPallet_Blue.svg");
            pendant.registerImageFile("images/RightArrow_Outline.svg");
            pendant.registerImageFile("images/LeftArrow_Outline.svg");
            pendant.registerImageFile("images/DownArrow_Outline.svg");
            pendant.registerImageFile("images/UpArrow_Outline.svg");
            pendant.registerImageFile("images/RightArrow_Filled.svg");
            pendant.registerImageFile("images/LeftArrow_Filled.svg");
            pendant.registerImageFile("images/DownArrow_Filled.svg");
            pendant.registerImageFile("images/UpArrow_Filled.svg");
            pendant.registerImageFile("images/Place2_White.png");
            pendant.registerImageFile("images/Pick_White.png");

            // Build Editor
            pendant.registerImageFile("images/Build.svg");

            // Wizard Images
            pendant.registerImageFile("images/Box.svg");
            pendant.registerImageFile("images/Pallet.svg");
            pendant.registerImageFile("images/Separator.svg");
            pendant.registerImageFile("images/Step1.png");
            pendant.registerImageFile("images/Step2.png");
            pendant.registerImageFile("images/Step3.png");
            pendant.registerImageFile("images/Step4.png");

            // CellSetup Wizard Images
            pendant.registerImageFile("images/Build.png");
            pendant.registerImageFile("images/Infeed2.png");
            pendant.registerImageFile("images/DispenserSearch2.png");
            pendant.registerImageFile("images/DispenserFixed.png");


            // --- Register Helps ---
            //Designate the page index that the help file will be associated with.

            //registerHelpFile(UiPageIndex.mainmenu, "PalletizingExt-help.html");
            //registerHelpFile(UiPageIndex.cellOperation, "CellOperation-help.html");
            //registerHelpFile(UiPageIndex.manageProducts, "ManageProducts-help.html");
            //registerHelpFile(UiPageIndex.editorPickPlace, "PickPlaceOperations-help.html");
            //registerHelpFile(UiPageIndex.manageJobs, "ManageJobs-help.html");
            //registerHelpFile(UiPageIndex.editorLayer, "EditorLayer-help.html");
            //registerHelpFile(UiPageIndex.editorPath, "EditorPath-help.html");
            //registerHelpFile(UiPageIndex.manageBuilds, "ManageBuilds-help.html");
            //registerHelpFile(UiPageIndex.editorBuild, "EditorBuild-help.html");
            //registerHelpFile(UiPageIndex.cellSetup, "CellSetup-help.html");
            //registerHelpFile(UiPageIndex.manageStations, "ManageStations-help.html");
            //registerHelpFile(UiPageIndex.manageGrippers, "ManageGrippers-help.html");
            //registerHelpFile(UiPageIndex.manageJobsPick, "ManageJobs-help.html");
            //registerHelpFile(UiPageIndex.manageJobsPlace, "ManageJobs-help.html");
            //registerHelpFile(UiPageIndex.wizard, "WizardMode-help.html");
            //registerHelpFile(UiPageIndex.wizardSetup, "GuidedCell-help.html");

            //pendant.registerHTMLFile(getHelpPath("Station-UF-Infeed.html"));
            //pendant.registerImageFile("images/Station-UF-Infeed.svg");
            //pendant.registerHTMLFile(getHelpPath("Station-UF-Build.html"));
            //pendant.registerImageFile("images/Station-UF-Build.svg");
            //pendant.registerHTMLFile(getHelpPath("Station-UF-DispenserSearch.html"));
            //pendant.registerImageFile("images/Station-UF-DispenserSearch.svg");
            //pendant.registerHTMLFile(getHelpPath("Station-UF-DispenserFixed.html"));
            //pendant.registerImageFile("images/Station-UF-DispenserFixed.svg");

            //pendant.registerImageFile(getHelpPath("Fixed_vs_Relative.png"));
            //pendant.registerImageFile(getHelpPath("PositionsStackSearch.png"));
            //pendant.registerImageFile(getHelpPath("Stations.png"));
            //pendant.registerImageFile(getHelpPath("StationsUnique.png"));

            pendant.registerImageFile("images/CustomPatternSnap.png");
            pendant.registerImageFile("images/CustomFixedRotation.png");
            pendant.registerImageFile("images/CustomRelativeRotation.png");

            pendant.registerImageFile("images/Block.png");
            pendant.registerImageFile("images/BuildMode.png");
            pendant.registerImageFile("images/Diagonal.png");
            pendant.registerImageFile("images/GroupMode.png");
            pendant.registerImageFile("images/Interlock.png");
            pendant.registerImageFile("images/Pinwheel.png");
            pendant.registerImageFile("images/SnapMode.png");
            pendant.registerImageFile("images/Labels.svg");

            pendant.registerImageFile("images/Center.svg");
            pendant.registerImageFile("images/CenterPallet.svg");
            pendant.registerImageFile("images/FitPage.svg");
            pendant.registerImageFile("images/ZoomIn2.png");
            pendant.registerImageFile("images/ZoomOut2.png");
            pendant.registerImageFile("images/MirrorHoriz2.svg");
            pendant.registerImageFile("images/MirrorVert2.svg");

            // Register it as a Utility window
            pendant.registerUtilityWindow("palletizingExt",  // id
                                        "PalletizingExt",    // YML item type
                                        "Demo",          // Menu name
                                        "Demo");         // Window title

            // run 'forever' (or until API service shuts down)
            extension.run(new Extension.BooleanSupplier(Idk));      //I guess you can pass in a callback function to kill the extension??
        }

        public bool Idk()
        {
            return (false);
        }

        static void Main(string[] args)
        {
            demoExtension21_csharp _demoExtension = null;
            try
            {
                // launch
                try
                {
                    _demoExtension = new demoExtension21_csharp();
                }
                catch (Exception _e)
                {
                    Console.WriteLine("Extension failed to start, aborting: " + _e);
                    return;
                }

                try
                {
                    _demoExtension.setup();
                }
                catch (Exception _e)
                {
                    Console.WriteLine("Extension failed in setup, aborting: " + _e);
                    return;
                }

                // run 'forever' (or until API service shutsdown)
                try
                {
                    _demoExtension.Run();
                }
                catch (Exception _e)
                {
                    Console.WriteLine("Exception occured:" + _e);
                }

            }
            catch (Exception _e)
            {

                Console.WriteLine("Exception: " + _e);

            }
            finally
            {
                if (_demoExtension != null)
                    _demoExtension.close();
            }
        }

        private void close()
        {
            Console.WriteLine("Closing");
        }
    }
}