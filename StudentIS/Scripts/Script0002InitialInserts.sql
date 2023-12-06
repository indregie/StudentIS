INSERT INTO departments VALUES
    (default, 'Physics', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
    (default, 'Arts', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Mathematics', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Law', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Philosophy', '2023-07-13', 'Indre', '2023-07-13', 'Indre');
	
INSERT INTO courses VALUES
    (default, 'Violin', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Guitar', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Drums', '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Music history', '2023-07-13', 'Indre', '2023-07-13', 'Indre');

INSERT INTO department_courses VALUES
    (default, 3, 1, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 3, 2, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 3, 3, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 3, 4, '2023-07-13', 'Indre', '2023-07-13', 'Indre');
	
INSERT INTO students VALUES
    (default, 'Rokas', 'Petrauskas', 1, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Giedre', 'Jankauskaite', 1, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Mantas', 'Kazlauskas', 3, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
    (default, 'Inga', 'Balciunaite', 3, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Tadas', 'Vaitkevicius', 4, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Ieva', 'Zilinskaite', 4, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Karolis', 'Siaurys', 5, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Jurga', 'Dambrauskaite', 5, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Arturas', 'Jonaitis', 6, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 'Agne', 'Stankeviciute', 6, '2023-07-13', 'Indre', '2023-07-13', 'Indre');

INSERT INTO course_students VALUES
    (default, 1, 1, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 2, 2, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 3, 3, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 4, 4, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 1, 5, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 2, 6, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 3, 7, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 4, 8, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 1, 9, '2023-07-13', 'Indre', '2023-07-13', 'Indre'),
	(default, 2, 10, '2023-07-13', 'Indre', '2023-07-13', 'Indre');