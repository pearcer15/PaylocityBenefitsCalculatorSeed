import React from 'react';
import Employee from './Components/Employee';
import { baseUrl } from './Utilities/Constants';
import AddEmployeeModal from './Components/Modals/AddEmployeeModal';

class EmployeeListing extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            employees: [],
            error: null,
            addEmployeeModalId: "add-employee-modal"
        }
    }
    componentDidMount = () => {
        this.getEmployees();
    }
    getEmployees = () => {
        fetch(`${baseUrl}/api/v1/Employees`)
        .then((raw) => raw.json())
        .then((response) => {
        if (response.success) {
            this.setState({
                employees: response.data,
                error: null
            })
        }
        else {
            this.setState({
                employees: [],
                error: response.error
            })
        }})
    };


    render() {

        return (
            <div className="employee-listing">
        <table className="table caption-top">
            <caption>Employees</caption>
            <thead className="table-dark">
                <tr>
                    <th scope="col">Id</th>
                    <th scope="col">LastName</th>
                    <th scope="col">FirstName</th>
                    <th scope="col">DOB</th>
                    <th scope="col">Salary</th>
                    <th scope="col">Dependents</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
            {this.state.employees.map(({id, firstName, lastName, dateOfBirth, salary, dependents}) => (
                <Employee
                key={id}
                id={id}
                firstName={firstName}
                lastName={lastName}
                dateOfBirth={dateOfBirth}
                salary={salary}
                dependents={dependents}
                editModalId={this.state.addEmployeeModalId}
                />
                ))}
            </tbody>
        </table>
        <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target={`#${this.state.addEmployeeModalId}`}>Add Employee</button>
        <AddEmployeeModal
            id={this.state.addEmployeeModalId}
            />
    </div>
    );
    }
};

export default EmployeeListing;