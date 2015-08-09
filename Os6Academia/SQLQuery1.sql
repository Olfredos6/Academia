use StudentData;
create table MySubject(
	ID int identity (0,1) primary key,
	SubjectName char (50) not null,
	FinalMark int not null,
)