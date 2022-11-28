import Modal from 'react-modal';

function AddDependentModal(props) {
    return (
        <div>
        <Modal
            isOpen={props.IsModalOpen}
            ariaHideApp={false}
        >
                        <h1 className="modal-title fs-5" id="add-dependent-modal-label">Add Dependent</h1>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    <div className="modal-body">
                        ...
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
        </Modal>
        </div>
    );
};

export default AddDependentModal;