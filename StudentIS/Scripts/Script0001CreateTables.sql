
CREATE TABLE IF NOT EXISTS public.departments (
   id serial primary key,
   name text unique not null,
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.students (
   id serial primary key,
   name text not null,
   surname text not null,
   department_id serial references public.departments(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.courses (
   id serial primary key,
   name text not null,
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.course_students (
   id serial primary key,
   course_id serial references public.courses(id),
   student_id serial references public.students(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.department_courses (
   id serial primary key,
   department_id serial references public.departments(id),
   course_id serial references public.courses(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);