import Dependent from '../Dependent';
import AddDependentModal from './AddDependentModal';
import Modal from 'react-modal';
import React from 'react';
import { currencyFormat } from '../../Utilities/Constants';
import { employeesUrl, fetchPost, fetchPut } from '../../Utilities/ApiService';

class AddEmployeeModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            addOpen: false,
            firstName: this.props.data.firstName || '',
            lastName: this.props.data.lastName || '',
            salary: this.props.data.salary || 0,
            dateOfBirth: this.props.data.dateOfBirth || '2000-01-01',
            dependents: this.props.data.dependents || []
            };

        this.handleChange = this.handleChange.bind(this);
    }

    onModalClose = () => {
        this.props.onCloseModal(false);
    }

    openAddModal = () => {
        this.setState({
         addOpen: true
        })
     }
 
     handleCloseAddModal = () => {
         this.setState({
             addOpen: false
         })
     }

     handleChange = (event) => {
        this.setState({
            [event.target.name]: event.target.value
        })
     }

     handleSubmit = () =>  {
        if(this.props.editMode) {
            fetchPut(`${employeesUrl}/${this.props.data.id}`, this.editEmployee());
        } else{
            fetchPost(`${employeesUrl}`, this.addEmployee());
        }
        this.props.onCloseModal(true);
     }

     addEmployee = () => {
        return {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            salary: this.state.salary,
            dateOfBirth: this.state.dateOfBirth,
            dependents: this.state.dependents
        };
     }

     editEmployee = () => {
        return {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            salary: this.state.salary
        }
 }

     render() {
    return (
        <div>
        <Modal
            isOpen={this.props.IsModalOpen}
            ariaHideApp={false}
        >
            <h1>Add/Edit Employee</h1>
            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close" onClick={this.onModalClose}></button>
            <div>
                <form>
                    <label>
                        First Name:
                        <input type="text" name="firstName" value={this.state.firstName} onChange={this.handleChange} />
                    </label>
                    <label>
                        Last Name:
                        <input type="text" name="lastName" value={this.state.lastName} onChange={this.handleChange} />
                    </label>
                    <label>
                        Salary $:
                        <input type="number" name="salary" value={this.state.salary} min="1" onChange={this.handleChange} />
                    </label>
                    <label>
                        Date of Birth:
                        <input disabled={this.props.editMode} type="date" name="dateOfBirth" value={this.state.dateOfBirth} onChange={this.handleChange} />
                    </label>

            <table className="table caption-top">
                <caption>Dependents</caption>
                <thead className="table-dark">
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">LastName</th>
                        <th scope="col">FirstName</th>
                        <th scope="col">DOB</th>
                        <th scope="col">Relationship</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                {this.state.dependents.map(({id, firstName, lastName, dateOfBirth, relationship}) => (
                    <Dependent
                    key={id}
                    id={id}
                    firstName={firstName}
                    lastName={lastName}
                    dateOfBirth={dateOfBirth.split("T")[0]}
                    relationship={relationship}
                    />
                    ))}
                </tbody>
            </table>
            <AddDependentModal
                data={[]}
                editMode={false}
                employeeId={this.props.data.id}
                IsModalOpen={this.state.addOpen}
                onCloseModal={this.handleCloseAddModal}
            />
            {/* Disabling the add Dependent button if we don't have an employee id yet */}
            <button disabled={!this.props.editMode} type="button" className="btn btn-primary" onClick={this.openAddModal}>Add Dependent</button>
            </form>
            </div>
            <div className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal" onClick={this.onModalClose}>Close</button>
                <button type="button" className="btn btn-primary" onClick={this.handleSubmit}>Save changes</button>
            </div>
        </Modal>
        </div>
    );
    }
};

export default AddEmployeeModal;