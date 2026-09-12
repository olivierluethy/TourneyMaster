# TourneyMaster

A Windows desktop app for building and simulating a knockout football tournament
bracket, built with C# and WPF. Pick teams into the bracket slots and let the app play
out the rounds.

## Features

- Choose from a built-in set of top clubs (Barcelona, Real Madrid, Bayern Munich, PSG,
  Atlético, Juventus, Manchester City, Chelsea), each with a club crest.
- Assign teams to bracket slots, with per-slot availability so a team can't be picked twice.
- Simulate the tournament stage by stage through to a winner.
- Team crests loaded from the bundled `images/` resources.

## Tech

- C# with WPF (XAML UI)
- .NET Framework 4.7.2
- Visual Studio solution (`Turnierspielplan.sln`)

## Run

Open `Turnierspielplan.sln` in Visual Studio and press **F5**, or build from the command line:

```bash
msbuild Turnierspielplan.sln
```

Then launch the compiled executable from the build output folder.
