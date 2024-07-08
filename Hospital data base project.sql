create database Hospital2
use Hospital2

create table Doctor(
doc_Name varchar(50)not Null,
doc_Gender varchar(50)not Null,
specialisation varchar(50)not Null,
doc_ID int primary key,
doc_Address varchar(50)not Null,
doc_Phone bigint not null
)

create table Nurse(
N_ID int primary key,
N_email varchar(50)not Null,
N_address varchar(50)not Null,
N_phone bigint not null ,
Nurse_Name Varchar(50) not null
)


create table Recaptinist(
Re_ID int primary key,
Re_Name varchar(50)not Null,
Re_address varchar(50)not Null,
Re_Gender varchar(50)not Null,
useName varchar(20)not Null,
pass varchar(20)not Null
)

create table Patient(
pati_ID int primary key,
pEn_date varchar(50)not Null,
pEx_date varchar(50)not Null,
pati_Gender varchar(50)not Null,
pati_Phone bigint not null,
re_ID int not null,
n_ID int not null,
FOREIGN KEY (re_ID) REFERENCES Recaptinist(Re_ID),
FOREIGN KEY (n_ID) REFERENCES Nurse(N_ID),
Patient_name varchar(50)not Null,
Payment int not null,
Age varchar(50)not Null,
)


create table Room(
Room_ID int primary key,
room_Type varchar(50)not Null
)


create table Room_Used(
Room_ID int ,
pati_ID int ,
FOREIGN KEY (Room_ID) REFERENCES Room (Room_ID),
FOREIGN KEY (pati_ID) REFERENCES Patient(pati_ID)
)



create table treatment(
doctor_Id int,
patient_ID int,
F_drug varchar(50),
S_drug varchar(50),
Doc_comm varchar(250),
Doc_name varchar(50),
Patiant_name varchar(50)
FOREIGN KEY (doctor_Id) REFERENCES Doctor (doc_ID),
FOREIGN KEY (patient_ID) REFERENCES Patient(pati_ID)
)


Insert into Recaptinist
Values (2020015,'bahaa shamoon','tema el gash','male','bahaa','12345')