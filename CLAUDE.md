# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

AnimalSim is a Unity 6000.0.24f1 project that simulates animal behavior using AI systems. It features reproduction, hunger, movement, and age mechanics in a 3D environment using Universal Render Pipeline (URP).

## Development Commands

**Primary Development:**
- Development is done through Unity Editor (Unity 6000.0.24f1)
- Main scene: `DemoLevel.unity` for gameplay testing
- Solution file: `AnimalSim.sln` for IDE integration
- Hot Reload is enabled for live code changes during play mode

**No build/test commands available** - Unity project uses Editor workflow

## Architecture & Key Systems

### Component-Based Entity Architecture

The core entity is `AnimalComponent` with modular components:
```
AnimalComponent (Main Entity)
├── AnimalData (ScriptableObject configuration)
├── Needs (Hunger system)
├── MovementController (Locomotion)
├── AnimatorController (Animation via Animancer)
├── AgeComponent (Aging and life stages)
├── ReproductionComponent (Mating and offspring)
└── FSMOwner (NodeCanvas state machine)
```

### Core Systems

**Animal Management (`Core.Animals`):**
- `AnimalManager` (Singleton) - Central registry with efficient lookup indexes
- Life cycle management: birth → growth → adult → reproduction → death
- Species tracking and adult female indexes for reproduction

**AI System (`Core.AI`):**
- Uses NodeCanvas for visual behavior trees and state machines
- Base class: `AnimalTask` extends NodeCanvas `ActionTask`
- Actions: `WanderAction`, `SearchForFoodAction`, `SearchForMateAction`, `EatAction`, `MateTask`
- Conditions: `IsHungryCondition`, `CanMate`, `HasFoodTargetCondition`

**Food System (`Core.Food`):**
- `FoodManager` (Singleton) - Spatial food tracking and queries
- `FoodSpawner` - Procedural food generation
- Spatial indexing for efficient food location

**Reproduction System (`Core.Animals.Reproduction`):**
- Gender-based mating system with pregnancy cycles
- Configurable offspring counts and gestation timing
- Adult maturity requirements for breeding

### Key Patterns

1. **Singleton Pattern**: `MonoSingleton<T>` base class for managers (`AnimalManager`, `FoodManager`)
2. **Data-Driven Design**: `AnimalData` and `AnimalStats` ScriptableObjects for configuration
3. **Component Composition**: Modular animal behaviors through components
4. **Event-Driven Systems**: Life cycle events for aging and reproduction
5. **Spatial Queries**: Efficient neighbor finding for AI behaviors

## Third-Party Dependencies

**Essential Asset Store Tools:**
- **Animancer** - Animation system (replaces Unity Animator Controllers)
- **NodeCanvas** - Visual scripting for AI behavior trees/FSMs
- **Odin Inspector** - Enhanced inspector with debugging attributes
- **DOTween** - Tweening and animation
- **Hot Reload** - Live code reloading

## Project Structure

```
Assets/Scripts/Core/
├── AI/              # NodeCanvas actions & conditions
├── Animals/         # Animal components & data
├── Animation/       # Animancer integration  
├── Food/           # Food system
└── State/          # Global managers

Assets/Data/         # ScriptableObject configurations
├── AnimalStats/    # Species configurations
├── Animals/        # Animal prefab data
└── Behaviors/      # AI behavior assets
```

## Development Guidelines

**Configuration Approach:**
- Use ScriptableObjects for all animal stats and behaviors
- Leverage Odin Inspector attributes: `[Title]`, `[AssetSelector]`, `[ShowIf]`
- Configure AI through NodeCanvas visual editor rather than code when possible

**Component Architecture:**
- Extend `AnimalTask` for new AI actions (not generic NodeCanvas `ActionTask`)
- Use `MonoSingleton<T>` for manager classes
- Follow component-based design - avoid monolithic animal classes

**Key Entry Points:**
- `AnimalComponent.cs` - Main entity with component references
- `AnimalManager.cs` - Central animal registry and spawning
- `AnimalTask.cs` - Base class for all AI actions
- `AnimalData.cs` - Configuration structure for animals

**Current Species Implementation:**
- Foxes: Carnivores that hunt rabbits
- Rabbits: Herbivores that eat grass and reproduce frequently
- Each species has distinct `AnimalStats` ScriptableObject configuration