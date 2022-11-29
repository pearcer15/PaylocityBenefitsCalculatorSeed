import React from 'react';
import Employee from './Components/Employee';
import { employeesUrl, fetchDelete, fetchGet, fetchPost } from './Utilities/ApiService';
import AddEmployeeModal from './Components/Modals/AddEmployeeModal';

class EmployeeListing extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            employees: [],
            error: null,
            addOpen: false
        }
    }
    componentDidMount = () => {
        this.getEmployees();
    }
    getEmployees = () => {
        fetchGet(`${employeesUrl}`)
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

    openAddModal = () => {
        this.setState({
         addOpen: true
        });
    }
 
    handleCloseAddModal = (reply) => {
        if(reply) {
            fetchPost(`${employeesUrl}`, reply)
            .then((response) => {
                var newEmployeeList = this.state.employees.concat(response.data);
                this.setState({
                    employees: newEmployeeList
                })
            })
        }
        this.setState({
            addOpen: false
        });
    }

    handleDelete = (id) => {
        fetchDelete(`${employeesUrl}/${id}`)
        .then((response) => {
            this.setState({
                employees: response.data
            })
        })
    }

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
                deleted={this.handleDelete}
                />
                ))}
            </tbody>
        </table>
        <AddEmployeeModal
            data={[]}
            editMode={false}
            IsModalOpen={this.state.addOpen}
            onCloseModal={this.handleCloseAddModal}
        />
        <button type="button" className="btn btn-primary" onClick={this.openAddModal} >Add Employee</button>
    </div>
    );
    }
};

export default EmployeeListing;