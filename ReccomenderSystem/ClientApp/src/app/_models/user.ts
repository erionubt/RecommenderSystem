import { Role } from "./role";

export class User {
  id: string;
  idRole: string;
  username: string;
  password: string;
  password_again: string;
  phone_number: string;
  email: string;
  firstName: string;
  lastName: string;
  role: Role;
  token?: string;
}
