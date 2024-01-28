# (PT-BR)
# Estratégias de Herança no Entity Framework Core

Este repositório demonstra as diferentes abordagens de herança utilizadas no Entity Framework Core: Table Per Hierarchy (TPH), Table Per Type (TPT) e Table Per Concrete class (TPC). Cada abordagem tem suas próprias características e é adequada para diferentes cenários.

## Table Per Hierarchy (TPH)

Na abordagem TPH, todas as classes na hierarquia de herança são mapeadas para uma única tabela. A tabela possui uma coluna discriminadora para diferenciar entre os tipos.

### Estrutura da Tabela TPH

#### Tabela: Vehicles

| Column        | Type    | Notas                            |
|---------------|---------|----------------------------------|
| Id            | int     | Chave Primária                   |
| Model         | string  |                                  |
| Year          | int     |                                  |
| Type          | string  | Discriminador (Car, Motorcycle)  |
| NumberOfDoors | int     | NULL para motocicletas           |
| HasFairing    | boolean | NULL para carros                 |

## Table Per Type (TPT)

A abordagem TPT mapeia cada classe na hierarquia de herança para sua própria tabela, com cada classe derivada tendo sua própria chave primária e uma chave estrangeira referenciando a tabela da classe base.

### Estrutura das Tabelas TPT

#### Tabela: Vehicles

| Column        | Type    | Notas                            |
|---------------|---------|----------------------------------|
| Id            | int     | Chave Primária                   |
| Model         | string  |                                  |
| Year          | int     |                                  |

#### Tabela: Cars

| Column        | Type    | Notas                            |
|---------------|---------|----------------------------------|
| Id            | int     | Chave Primária                   |
| VehicleId     | int     | Chave Estrangeira para Vehicles  |
| NumberOfDoors | int     |                                  |

#### Tabela: Motorcycles

| Column     | Type    | Notas                               |
|---------------|---------|----------------------------------|
| Id            | int     | Chave Primária                   |
| VehicleId     | int     | Chave Estrangeira para Vehicles  |
| HasFairing    | boolean |                                  |

## Table Per Concrete class (TPC)

Na abordagem TPC, cada classe concreta na hierarquia de herança é mapeada para sua própria tabela, e a classe base não é representada.

### Estrutura das Tabelas TPC

#### Tabela: Cars

| Column        | Type   | Notas                            |
|---------------|--------|----------------------------------|
| Id            | int    | Chave Primária                   |
| Model         | string |                                  |
| Year          | int    |                                  |
| NumberOfDoors | int    |                                  |

#### Tabela: Motorcycles

| Column        | Type    | Notas                            |
|---------------|---------|----------------------------------|
| Id            | int     | Chave Primária                   |
| Model         | string  |                                  |
| Year          | int     |                                  |
| HasFairing    | boolean |                                  |

---

Para mais informações sobre como implementar cada uma dessas abordagens no Entity Framework Core, consulte a documentação oficial.


# (EN-US)
# Inheritance Strategies in Entity Framework Core

This repository demonstrates the different inheritance approaches used in Entity Framework Core: Table Per Hierarchy (TPH), Table Per Type (TPT), and Table Per Concrete class (TPC). Each approach has its own characteristics and is suitable for different scenarios.

## Table Per Hierarchy (TPH)

In the TPH approach, all classes in the inheritance hierarchy are mapped to a single table. The table has a discriminator column to differentiate between the types.

### TPH Table Structure

#### Tabela: Vehicles

| Column        | Type    | Notes                            |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| Model         | string  |                                  |
| Year          | int     |                                  |
| Type          | string  | Discriminator (Car, Motorcycle)  |
| NumberOfDoors | int     | NULL for motorcycles             |
| HasFairing    | boolean | NULL for cars                    |

## Table Per Type (TPT)

The TPT approach maps each class in the inheritance hierarchy to its own table, with each derived class having its own primary key and a foreign key referencing the base class table.

### TPT Table Structures

#### Table: Vehicles

| Column        | Type    | Notes                            |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| Model         | string  |                                  |
| Year          | int     |                                  |

#### Table: Cars

| Column        | Type    | Notes                            |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| VehicleId     | int     | Foreign Key to Vehicles          |
| NumberOfDoors | int     |                                  |

#### Table: Motorcycles

| Column     | Type    | Notes                               |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| VehicleId     | int     | Foreign Key to Vehicles          |
| HasFairing    | boolean |                                  |

## Table Per Concrete class (TPC)

In the TPC approach, each concrete class in the inheritance hierarchy is mapped to its own table, and the base class is not represented.

### TPC Table Structures

#### Table: Cars

| Column        | Type    | Notes                            |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| Model         | string  |                                  |
| Year          | int     |                                  |
| NumberOfDoors | int     |                                  |

#### Table: Motorcycles

| Column        | Type    | Notes                            |
|---------------|---------|----------------------------------|
| Id            | int     | Primary Key                      |
| Model         | string  |                                  |
| Year          | int     |                                  |
| HasFairing    | boolean |                                  |

---

For more information on how to implement each of these approaches in Entity Framework Core, consult the official documentation.

