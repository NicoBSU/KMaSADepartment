export class UserRegistrationDto {
    userName: string;
    password: string;
    confirmPassword: string;
    user: {
        dateOfBirth: string,
        firstName: string,
        lastName: string,
        middleName?: string,
        photo: {
            id: number
            url?: string,
        }    
    };

    userType: number;

    mentor: {
        title: string,
        biography?: string
    };

    student:{
        id: number,
        course:{
            id: number,
            number: number,
        }
    }

    constructor(
        userName: string, 
        password: string, 
        confirmPassword: string,
        dateOfBirth: string,
        firstName: string,
        lastName: string,
        userType: string,
        title: string,
        course: number,
        middleName?: string,
        url?: string,){
            this.mentor.title = title;
            this.userName = userName;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.user.dateOfBirth = dateOfBirth;
            this.user.firstName = firstName;
            this.user.lastName = lastName;
            if(userType === 'Студент'){
                this.userType = 1
            }
            else if(userType === 'Преподаватель'){
                this.userType = 0;
            }

            this.student.course.number = course;
            this.user.photo.url = url;
            this.user.middleName = middleName;
    }
}