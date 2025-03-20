function prompt {
        if git status &> /dev/null; then
                modified_files=$(git status --porcelain | wc -l)
                PS1="\u@\h:\w [${modified_files} modified files]\$"
        else
                free_space=$(df -h . | tail -1 | awk '{print $4}')
                count_files=$(find . -maxdepth 1 -type f | wc -l)
                PS1="\u@\h:\w [${free_space} of free space, ${count_files} files]\$"
        fi
}
PROMPT_COMMAND=prompt