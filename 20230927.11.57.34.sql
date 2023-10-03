--Manual Additions
CREATE role student_rw;

--
-- PostgreSQL database dump
--

-- Dumped from database version 12.14
-- Dumped by pg_dump version 15.4 (Debian 15.4-1.pgdg120+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: dadabase_f23; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA dadabase_f23;


ALTER SCHEMA dadabase_f23 OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: audience; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.audience (
    id integer NOT NULL,
    audiencename character varying,
    description character varying(64)
);


ALTER TABLE dadabase_f23.audience OWNER TO postgres;

--
-- Name: audiencecategory; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.audiencecategory (
    id integer NOT NULL,
    categoryname character varying,
    description character varying(64)
);


ALTER TABLE dadabase_f23.audiencecategory OWNER TO postgres;

--
-- Name: categorizedaudience; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.categorizedaudience (
    id integer NOT NULL,
    audienceid integer NOT NULL,
    audiencecategoryid integer NOT NULL
);


ALTER TABLE dadabase_f23.categorizedaudience OWNER TO postgres;

--
-- Name: categorizedjoke; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.categorizedjoke (
    id integer NOT NULL,
    jokeid integer,
    jokecategoryid integer
);


ALTER TABLE dadabase_f23.categorizedjoke OWNER TO postgres;

--
-- Name: deliveredjoke; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.deliveredjoke (
    id integer NOT NULL,
    delivereddate date DEFAULT CURRENT_DATE,
    jokereactionid integer,
    jokeid integer,
    audienceid integer,
    notes character varying(64)
);


ALTER TABLE dadabase_f23.deliveredjoke OWNER TO postgres;

--
-- Name: joke; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.joke (
    id integer NOT NULL,
    jokename character varying,
    joketext character varying(128)
);


ALTER TABLE dadabase_f23.joke OWNER TO postgres;

--
-- Name: jokecategory; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.jokecategory (
    id integer NOT NULL,
    categoryname character varying,
    description character varying(64)
);


ALTER TABLE dadabase_f23.jokecategory OWNER TO postgres;

--
-- Name: jokereactioncategory; Type: TABLE; Schema: dadabase_f23; Owner: postgres
--

CREATE TABLE dadabase_f23.jokereactioncategory (
    id integer NOT NULL,
    reactionlevel character varying(16),
    description character varying(64)
);


ALTER TABLE dadabase_f23.jokereactioncategory OWNER TO postgres;

--
-- Data for Name: audience; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.audience (id, audiencename, description) FROM stdin;
0	English Class	\N
1	French Class	\N
2	Psychology Class	\N
3	Family Dinner Table	Location may vary
4	Department Meeting	Department may vary
5	Roommates	\N
200	Edited Autiend	\N
\.


--
-- Data for Name: audiencecategory; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.audiencecategory (id, categoryname, description) FROM stdin;
0	tech	a collection of nerds
1	family	keeping it friendly for all ages
2	religious	\N
3	workplace	OSHA approved
\.


--
-- Data for Name: categorizedaudience; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.categorizedaudience (id, audienceid, audiencecategoryid) FROM stdin;
\.


--
-- Data for Name: categorizedjoke; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.categorizedjoke (id, jokeid, jokecategoryid) FROM stdin;
\.


--
-- Data for Name: deliveredjoke; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.deliveredjoke (id, delivereddate, jokereactionid, jokeid, audienceid, notes) FROM stdin;
1	2023-09-11	1	2	1	It did not go so well
2	2023-09-11	0	2	4	they love me!
3	2023-09-22	2	3	1	woo!
4	2023-08-11	2	4	1	yahoo!
5	2023-10-20	2	1	1	:)
1000	2023-09-24	0	0	0	wahoo I changed this yeehaw I am the best
0	2023-08-10	0	1	0	They loved it :)
200	2023-08-10	1	3	5	Booyeah
\.


--
-- Data for Name: joke; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.joke (id, jokename, joketext) FROM stdin;
0	blind dinosaur	What do you call a blind dinosaur? A do-you-think-he-saurus.
1	golden soup	How do you turn soup into gold? Add 24 carrots.
2	tallest building	Which building has the most stories? The library.
3	holy shoemakers	Why do shoemakers go to heaven? They have good soles.
4	baseball breakfast	What did the pancake say to the baseball player? Batter up!
10	test	testing
205	Dusteez Blind Joke (Updated)	NEW and IMPROVED joke
221	Old woman at the well	Why did the old woman fall down the well? She did see that well.                                                                
222	The Confused Computer	Why did the computer keep freezing at the comedy club? Because it couldnt find its space bar!
223	bread	The other day I saw a baguette in a cage. It was bread in captivity.
224	chicken	Why did the chicken cross the road? *chicken noise* BECAUSE
225	penguin	How does a penguin build its house? Igloos it together
226	Tree Joke	Name the kind of tree you can hold in your hand? A palm tree!
227	Switzerland	What’s the best thing about Switzerland?¶I don’t know, but the flag is a big plus.
228	Dads store jokes	Where do dads keep their dad jokes? In a DadaBase
229	The Forgetful Baker	What did the forgetful baker say when he lost his rolling pin? "I knead that!"
230	odd marriage	I just read that 4,153,237 people got married last year. Not to cause any trouble, but shouldn't that be an even number
231	darkmode	Why do programmers use the dark mode? Because light attracts bugs
232	too weak	I tried to get a job, but the weights were too heavy so I put in my too weak notice
233	Teddy Bear Joke	Why did the teddy bear say no to dessert? Because she was stuffed.
234	Mathematician	Did you hear about the mathematician who’s afraid of negative numbers?¶He’ll stop at nothing to avoid them.
235	mens hair cuts	What do you call a line of men waiting to get their hair cut? A Barber-Que
236	The Musical Frog	What do you call a frog that likes to play basketball? A jump shot!
237	stick	What is brown and sticky? A stick
238	Scarecrow	Why did the scarecrow win an award? Because he was outstanding in his field
239	Chimpanzee Joke	What do you call a couple of chimpanzees sharing an Amazon account? PRIME-mates.
240	Scientists	Why don’t scientists trust atoms?¶Because they make up everything.
242	The Math Magician	Why did the math book look sad? Because it had too many problems!
243	book	Have you read the anti-gravity book? Its imposible to put down.
244	Piano	I used to play piano by ear, but now I use my hands.
245	Math Joke	Why was 6 afraid of 7? Because 7,8,9.
246	Moses	How does Moses make tea?¶He brews.
\.


--
-- Data for Name: jokecategory; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.jokecategory (id, categoryname, description) FROM stdin;
2	irony	eyeronic!
3	riddles	\N
0	puns	Exploiting multiple meanings of a word
5	immature	poo/pee crass jokes
6	antijoke	was that even a joke?
\.


--
-- Data for Name: jokereactioncategory; Type: TABLE DATA; Schema: dadabase_f23; Owner: postgres
--

COPY dadabase_f23.jokereactioncategory (id, reactionlevel, description) FROM stdin;
0	Big Laugh	A crowd roaring with laughter
1	Average Laugh	One step above a pity laugh
2	Failure to Laugh	Bad joke. Time to sit down.
\.


--
-- Name: audience audience_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.audience
    ADD CONSTRAINT audience_pkey PRIMARY KEY (id);


--
-- Name: audiencecategory audiencecategory_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.audiencecategory
    ADD CONSTRAINT audiencecategory_pkey PRIMARY KEY (id);


--
-- Name: categorizedaudience categorizedaudience_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedaudience
    ADD CONSTRAINT categorizedaudience_pkey PRIMARY KEY (id);


--
-- Name: categorizedjoke categorizedjoke_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedjoke
    ADD CONSTRAINT categorizedjoke_pkey PRIMARY KEY (id);


--
-- Name: deliveredjoke deliveredjoke_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.deliveredjoke
    ADD CONSTRAINT deliveredjoke_pkey PRIMARY KEY (id);


--
-- Name: joke joke_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.joke
    ADD CONSTRAINT joke_pkey PRIMARY KEY (id);


--
-- Name: jokecategory jokecategory_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.jokecategory
    ADD CONSTRAINT jokecategory_pkey PRIMARY KEY (id);


--
-- Name: jokereactioncategory jokereactioncategory_pkey; Type: CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.jokereactioncategory
    ADD CONSTRAINT jokereactioncategory_pkey PRIMARY KEY (id);


--
-- Name: categorizedaudience categorizedaudience_audiencecategoryid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedaudience
    ADD CONSTRAINT categorizedaudience_audiencecategoryid_fkey FOREIGN KEY (audiencecategoryid) REFERENCES dadabase_f23.audiencecategory(id);


--
-- Name: categorizedaudience categorizedaudience_audienceid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedaudience
    ADD CONSTRAINT categorizedaudience_audienceid_fkey FOREIGN KEY (audienceid) REFERENCES dadabase_f23.audience(id);


--
-- Name: categorizedjoke categorizedjoke_jokecategoryid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedjoke
    ADD CONSTRAINT categorizedjoke_jokecategoryid_fkey FOREIGN KEY (jokecategoryid) REFERENCES dadabase_f23.jokecategory(id);


--
-- Name: categorizedjoke categorizedjoke_jokeid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.categorizedjoke
    ADD CONSTRAINT categorizedjoke_jokeid_fkey FOREIGN KEY (jokeid) REFERENCES dadabase_f23.joke(id);


--
-- Name: deliveredjoke deliveredjoke_audienceid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.deliveredjoke
    ADD CONSTRAINT deliveredjoke_audienceid_fkey FOREIGN KEY (audienceid) REFERENCES dadabase_f23.audience(id);


--
-- Name: deliveredjoke deliveredjoke_jokeid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.deliveredjoke
    ADD CONSTRAINT deliveredjoke_jokeid_fkey FOREIGN KEY (jokeid) REFERENCES dadabase_f23.joke(id);


--
-- Name: deliveredjoke deliveredjoke_jokereactionid_fkey; Type: FK CONSTRAINT; Schema: dadabase_f23; Owner: postgres
--

ALTER TABLE ONLY dadabase_f23.deliveredjoke
    ADD CONSTRAINT deliveredjoke_jokereactionid_fkey FOREIGN KEY (jokereactionid) REFERENCES dadabase_f23.jokereactioncategory(id);


--
-- Name: SCHEMA dadabase_f23; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON SCHEMA dadabase_f23 TO student_rw;


--
-- Name: TABLE audience; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.audience TO student_rw;


--
-- Name: TABLE audiencecategory; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.audiencecategory TO student_rw;


--
-- Name: TABLE categorizedaudience; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.categorizedaudience TO student_rw;


--
-- Name: TABLE categorizedjoke; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.categorizedjoke TO student_rw;


--
-- Name: TABLE deliveredjoke; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.deliveredjoke TO student_rw;


--
-- Name: TABLE joke; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.joke TO student_rw;


--
-- Name: TABLE jokecategory; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.jokecategory TO student_rw;


--
-- Name: TABLE jokereactioncategory; Type: ACL; Schema: dadabase_f23; Owner: postgres
--

GRANT ALL ON TABLE dadabase_f23.jokereactioncategory TO student_rw;


--
-- PostgreSQL database dump complete
--

