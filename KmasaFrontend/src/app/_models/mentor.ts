import { CourseWork } from "./course-work";
import { StudyResource } from './study-resource';
import { Subject } from './subject';

export interface Mentor{
    id: number;
    userId: number;
    user: {
        userType: string,
        firstName: string,
        lastName: string,
        middleName?: string,
        email: string,
        photo: {
            id: number
            url?: string,
        }    
        dateOfBirth: string,
    };

    title: string;
    biography: string;
    courseWorks: CourseWork[];
    subjects: Subject[];
    publications: StudyResource[];
}