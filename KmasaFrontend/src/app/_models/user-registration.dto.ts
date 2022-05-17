export interface UserRegistrationDto {
    userName: string;
    password: string;
    confirmPassword: string;
    user: {
        dateOfBirth: string,
        firstName: string,
        lastName: string,
        middleName: string | null,
        photo: {
            id: number
            url: string | null,
        }    
    };

    userType: number;

    mentor: {
        title: string,
        biography: string
    };

    student:{
        id: number,
        course:{
            id: number,
            number: number,
        }
    }
}