create table Schools(
	id int primary key,
    fullName varchar(32) not null,
    area varchar(32) not null
);

create table Domains(
	id int primary key,
    name varchar(32) not null
);

create table Classes(
	id int primary key,
    name varchar(32) not null,
    year smallint not null
);

create table Students(
	id int primary key,
    schoolId int,
    firstName varchar(32) not null,
    lastName varchar(32) not null,
    gender varchar(16) not null,
    dateOfBirth datetime not null,
    maximumJustifiedAbsences int default 57,
    maximumUnJustifiedAbsences int default 142,
    foreign key(schoolId) references Students(id)
);

create table Certificates(
	id int primary key,
    studentId int,
    classId int,
    finalDegree float not null,
    date datetime,
    foreign key(studentId) references students(id)
);

create table Teachers(
	id int primary key,
    role varchar(32) not null,
    email varchar(64) not null,
    firstName varchar(32) not null,
    lastName varchar(32) not null,
    dateOfBirth datetime not null,
    speciality varchar(32) not null
);

create table TeachersPerSchool(
	teacherId int,
    schoolId int,
    primary key(teacherId, schoolId),
    foreign key(teacherId) references Teachers(id),
    foreign key(schoolId) references Schools(id)
);

create table Courses(
	id int primary key,
    classId int,
    domainId int,
    name varchar(32) not null,
    hoursPerWeek smallint not null,
    foreign key(classId) references Classes(id),
    foreign key(domainId) references Domains(id)
);

create table Classrooms(
	id int primary key,
    schoolId int,
    domainId int,
    classId int,
    name varchar(8) not null,
    floor smallint not null,
    foreign key(schoolId) references Schools(id),
    foreign key(classId) references Classes(id),
    foreign key(domainId) references Domains(id)
);

create table StudentsPerClassroom(
	studentId int,
    classroomId int,
    primary key(studentId,classroomId),
    foreign key(studentId) references Students(id),
    foreign key(classroomId) references Classrooms(id)
);

create table Grades(
	id int primary key,
    studentId int,
    teacherId int,
    courseId int,
    grade float not null,
    semester smallint not null,
    foreign key(studentId) references Students(id),
    foreign key(teacherId) references Teachers(id),
    foreign key(courseId) references Courses(id)
);

create table TeachingHours(
	id int primary key,
    teacherId int,
    classroomId int,
    courseId int,
    day smallint not null,
    hour smallint not null,
    foreign key(teacherId) references Teachers(id),
    foreign key(classroomId) references Classrooms(id),
    foreign key(courseId) references Courses(id)
);

create table Absences(
	id int,
    studentId int,
    teachingHourId int,
    justified bool not null,
    isPunishment bool not null,
    date datetime not null,
    foreign key(studentId) references Students(id),
    foreign key(teachingHourId) references TeachingHours(id)
);