
CREATE TABLE IF NOT EXISTS public.departments (
   id uuid primary key,
   name text unique not null,
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.students (
   id uuid primary key,
   name text not null,
   surname text not null,
   department_id uuid references public.departments(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.courses (
   id uuid primary key,
   name text not null,
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.course_students (
   id uuid primary key,
   course_id uuid references public.courses(id),
   student_id uuid references public.students(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);

CREATE TABLE IF NOT EXISTS public.department_courses (
   id uuid primary key,
   department_id uuid references public.departments(id),
   course_id uuid references public.courses(id),
   created date,
   created_by text,
   modified date,
   modified_by text
);